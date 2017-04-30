//First with mouse, to get everything worked out without controllers.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSetup : MonoBehaviour
{
    [Header("Auto Setup")]
    public bool generate;
    public bool update;
    public bool assignBlocks;


    [Header("Setup Parameters")]
    public int amountOfPlayers;
    public int amountOfBlocksEach;
    public List<Material> materials;
    public List<GameObject> prefabs;

    [Header("Players")]
    public List<Player> players;

    void Update()
    {
        if (generate)
        {
            GeneratePlayers();
            generate = false;
        }

        if (update)
        {
            UpdatePlayer();
            update = false;
        }

        if (assignBlocks) {
            AssignBlocks();
            assignBlocks = false;
        }
    }

    void GeneratePlayers()
    {
        players.Clear();
        for (int i = 0; i < amountOfPlayers; i++)
        {
            players.Add(new Player(i + 1, InputMode.Keyboard, materials[i]));
            players[i].UpdateBlocks(amountOfBlocksEach);
            AssignBlocks();
        }
    }

    void UpdatePlayer()
    {
        foreach (Player p in players)
        {
            p.UpdateInputMode(p.inputMode);
            p.UpdateBlocks(amountOfBlocksEach);
            AssignBlocks();
        }
    }

    void AssignBlocks() {
        foreach (Player p in players)
        {
            foreach (BlockObj b in p.blocks) {
                int i = Random.Range(0, prefabs.Count);
                b.block = prefabs[i];
            }
        }
    }
}

public enum InputMode
{
    Keyboard,
    Mouse,
    Controller
}

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

    [Header("Setup Parameters")]
    public int amountOfPlayers;
    public int amountOfBlocksEach;

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
    }

    void GeneratePlayers()
    {
        players.Clear();
        for (int i = 0; i < amountOfPlayers; i++)
        {
            players.Add(new Player(i + 1, InputMode.Keyboard, amountOfBlocksEach));
        }
    }

    void UpdatePlayer()
    {
        foreach (Player p in players)
        {
            p.UpdateInputMode(p.inputMode);
            p.UpdateBlocks(amountOfBlocksEach);
        }
    }
}

public enum InputMode
{
    Keyboard,
    Mouse,
    Controller
}

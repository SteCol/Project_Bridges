//First with mouse, to get everything worked out without controllers.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSetup : MonoBehaviour
{

    public bool generate;
    public bool update;

    public int amountOfPlayers;

    public List<Player> players;

    void Start()
    {

    }

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
            players.Add(new Player(i + 1, InputMode.Keyboard));
        }
    }

    void UpdatePlayer()
    {
        foreach (Player p in players)
        {
            if (p.inputMode != p.inputModeOld)
            {
                p.inputModeOld = p.inputMode;
                p.horizontalInput = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Horizontal";
                p.verticalInput = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Vertical";
                p.button = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Button";
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

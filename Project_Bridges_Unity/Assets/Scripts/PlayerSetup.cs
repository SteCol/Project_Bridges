//First with mouse, to get everything worked out without controllers.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerSetup : MonoBehaviour {

    public bool generate;
    public bool update;

    public int amountOfPlayers;

    public List<Player> players;

    void Start() {
        
    }

    void Update() {
        if (generate) {
            players.Clear();
            for (int i = 1; i <= amountOfPlayers; i++) {
                players.Add(new Player(i, InputMode.Keyboard));
            }
            generate = false;
        }

        if (update) {
            foreach (Player p in players) {
                if (p.inputMode != p.inputModeOld) {
                    p.inputModeOld = p.inputMode;
                    p.horizontalInput = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Horizontal";
                    p.verticalInput = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Vertical";
                    p.button = "Player_" + p.playerNum + "_" + p.inputMode.ToString() + "_Button";
                }
            }
            update = false;
        }
    }
}

public enum InputMode{
    Keyboard,
    Mouse,
    Controller
}

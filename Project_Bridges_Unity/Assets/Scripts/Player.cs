using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {

    public string name;

    [Header("Setup")]
    public int playerNum;
    public InputMode inputMode;
    public InputMode inputModeOld;

    [Header("Inputs")]
    public string horizontalInput;
    public string verticalInput;
    public string button;

    [Header("Blocks")]
    public List<GameObject> blocks;

    public Player(int _playerInt, InputMode _inputMode) {
        name = "Player_" + _playerInt;
        playerNum = _playerInt;
        inputMode = _inputMode;
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        button = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {

    public string name;

    [Header("Setup")]
    public int playerNum;
    public InputMode inputMode;
    public Material material;

    [Header("Inputs")]
    public string horizontalInput;
    public string verticalInput;
    public string button;

    [Header("Blocks")]
    public List<BlockObj> blocks = new List<BlockObj>();

    public Player(int _playerInt, InputMode _inputMode, Material _material) {
        name = "Player_" + _playerInt;
        playerNum = _playerInt;
        inputMode = _inputMode;
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        button = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
        material = _material;

    }

    public void UpdateInputMode(InputMode _inputMode) {
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        button = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
    }

    public void UpdateBlocks(int _amountOfBlocks) {
        blocks.Clear();
        for (int i = 0; i < _amountOfBlocks; i++)
        {
            blocks.Add(new BlockObj("Block_" + i, material));
        }
    }

}

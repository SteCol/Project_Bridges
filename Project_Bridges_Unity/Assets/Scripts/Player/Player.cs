using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {

    public string name;

    [Header("Setup/Info")]
    public int playerNum;
    public InputMode inputMode;
    public Material material;
    public Material outline;
    public GameObject inGamePlayer;
    public bool busy;

    [Header("Inputs: Position Movement")]
    public string horizontalInput;
    public float xPos;
    public string verticalInput;
    public float yPos;

    [Header("Inputs: Interaction")]
    public string buttonInput;
    public bool action;

    [Header("Inputs: Rotation")]
    public string rotationInput;
    public float rot;

    [Header("Blocks")]
    public List<BlockObj> blocks = new List<BlockObj>();

    public Player(int _playerInt, InputMode _inputMode, Material _material) {
        name = "Player_" + _playerInt;
        playerNum = _playerInt;
        inputMode = _inputMode;
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        buttonInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
        rotationInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Rotation";

        material = _material;

    }

    public Player(int _playerInt, InputMode _inputMode, Material _material, Material _outline)
    {
        name = "Player_" + _playerInt;
        playerNum = _playerInt;
        inputMode = _inputMode;
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        buttonInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
        rotationInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Rotation";

        material = _material;
        outline = _outline;

    }

    public void UpdateInputMode(InputMode _inputMode) {
        horizontalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Horizontal";
        verticalInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Vertical";
        buttonInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Button";
        rotationInput = "Player_" + playerNum + "_" + inputMode.ToString() + "_Rotation";
    }

    public void UpdateBlocks(int _amountOfBlocks) {
        blocks.Clear();
        for (int i = 0; i < _amountOfBlocks; i++)
        {
            blocks.Add(new BlockObj("Block_" + i, material, outline));
        }
    }

    public void Move() {
        xPos = Input.GetAxis(horizontalInput);
        yPos = Input.GetAxis(verticalInput);
        action = Input.GetButton(buttonInput);
        rot = rot - Input.GetAxis(rotationInput) * 5;

        if (inGamePlayer != null)
        {
            inGamePlayer.transform.Translate(new Vector3(xPos * Time.deltaTime * 25, 0, yPos * Time.deltaTime * 25), Space.World);
            inGamePlayer.transform.localEulerAngles = new Vector3(0, rot, 0);
        }
    }
}

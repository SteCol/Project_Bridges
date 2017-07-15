using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class UI_PlayerSettings : MonoBehaviour
{

    [Header("Sliders")]
    public List<Slider> sliders;
    public List<Text> num;

    [Header("Stuff")]
    public List<_UIPlayer> playerOccupied;
    public bool mousePicked;

    private List<string> allInputs;
    private List<string> detectedInputs;
    private List<string> activeInputs;

    void Update()
    {
        GetInputs();
    }

    public void UpdateText()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            num[i].text = sliders[i].value.ToString();
        }
    }

    void GetInputs()
    {
        //Inputs to check
        //LMB (1)
        //Key 1 2 3 4
        //Button A 1 2 3 4

        for (int i = 1; i <= 4; i++)
        {
            if (!playerOccupied[i - 1].occupied)
            {
                if (Input.GetAxis("Player_" + i + "_Mouse_Button") != 0 && !mousePicked) //MouseInput
                {
                    if (playerOccupied[i - 1].occupied != true)
                    {
                        OccupyPlayer(i, InputMode.Mouse);
                        mousePicked = true;
                    }
                }

                if (Input.GetAxis("Player_" + i + "_Keyboard_Button") != 0) //KeyboardInput
                    OccupyPlayer(i, InputMode.Keyboard);

                if (Input.GetAxis("Player_" + i + "_Controller_Button") != 0) //ControllerInput
                    OccupyPlayer(i, InputMode.Controller);
            }
        }
    }

    public void OccupyPlayer(int _num, InputMode _inputmode)
    {
        Debug.Log("Occupied Player " + (_num - 1) + " with " + _inputmode.ToString());
        playerOccupied[_num - 1].occupied = true;
        playerOccupied[_num - 1].inputMode = _inputmode;
        playerOccupied[_num - 1].text.text = _inputmode.ToString();
    }

    public enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };
}

[System.Serializable]
public class _UIPlayer {
    public bool occupied;
    public InputMode inputMode;
    public Text text;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UI_PlayerSettings : MonoBehaviour
{

    [Header("Sliders")]
    public List<Slider> sliders;
    public List<Text> num;

    public bool player1Occupied;
    public bool player2Occupied;
    public bool player3Occupied;
    public bool player4Occupied;

    public List<bool> playerOccupied;

    public List<string> allInputs;
    public List<string> detectedInputs;
    public List<string> activeInputs;


    // Use this for initialization
    void Start()
    {
        playerOccupied = new List<bool>(4);
        GetInputs();
        GetPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayers();
    }

    public void UpdateText()
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            num[i].text = sliders[i].value.ToString();
        }
    }

    public void GetInputs()
    {

        //FROM http://answers.unity3d.com/questions/951770/get-array-of-all-input-manager-axes.html
        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

        SerializedObject obj = new SerializedObject(inputManager);

        SerializedProperty axisArray = obj.FindProperty("m_Axes");

        if (axisArray.arraySize == 0)
            Debug.Log("No Axes");

        for (int i = 0; i < axisArray.arraySize; ++i)
        {
            var axis = axisArray.GetArrayElementAtIndex(i);

            var name = axis.FindPropertyRelative("m_Name").stringValue;
            allInputs.Add(name);
            var axisVal = axis.FindPropertyRelative("axis").intValue;
            var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

            //Debug.Log(name);
            //Debug.Log(axisVal);
            //Debug.Log(inputType);
        }
    }

    public void GetPlayers() {

        //foreach (string s in allInputs) {
        //    if (Input.GetAxis(s) != 0 && !detectedInputs.Contains(s)) {
        //        string[] inputSplit = s.Split('_'); //get the player number
        //        detectedInputs.Add(s); //place the inputs in a thing.
        //        foreach (string sa in detectedInputs)
        //        {
        //            string[] activeSplit = sa.Split('_');
        //            if (inputSplit[1] == activeSplit[1] && !activeInputs.Contains(s))
        //            {
        //                activeInputs.Add(s);
        //            }
        //        }
        //    }
        //}

        for (int i = 0; i < playerOccupied.Count; i++)
        {
            if (!playerOccupied[i])
            {
                foreach (string s in allInputs)
                {
                    if (Input.GetAxis(s) != 0)
                    {
                        string[] inputSplit = s.Split('_'); //get the player number
                        if (i == int.Parse(inputSplit[1])) {
                            playerOccupied[i] = true;
                        }
                    }
                }
            }
        }
    }

    public enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };
}



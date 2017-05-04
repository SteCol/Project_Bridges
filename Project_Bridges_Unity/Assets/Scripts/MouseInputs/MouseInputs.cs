using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RawMouseDriver;
using RawInputSharp;

public class MouseInputs : MonoBehaviour
{

    RawMouseDriver.RawMouseDriver mousedriver;
    private RawMouse[] mice;
    private Vector2[] move;
    public int NUM_MICE;

    // Use this for initialization
    void Start()
    {
        mousedriver = new RawMouseDriver.RawMouseDriver();
        mice = new RawMouse[NUM_MICE];
        move = new Vector2[NUM_MICE];
    }

    void Update()
    {
        // Loop through all the connected mice
        for (int i = 0; i < mice.Length; i++)
        {
            try
            {
                mousedriver.GetMouse(i, ref mice[i]);
                // Cumulative movement
                move[i] += new Vector2(mice[i].XDelta, -mice[i].YDelta);
            }
            catch { }
        }
    
        for (int i = 0; i < mice.Length; i++)
        {
            if (mice[i] != null)
                print("Mouse[" + i.ToString() + "] : " + move[i] + mice[i].Buttons[0] + mice[i].Buttons[1]);
        }
    }

    /*
    void OnApplicationQuit()
    {
        // Clean up
        mousedriver.Dispose();
    }
    */
}
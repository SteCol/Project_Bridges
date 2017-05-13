using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public bool isActive;

	// Use this for initialization
	void Start () {
        if (isActive) {
            Time.timeScale = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

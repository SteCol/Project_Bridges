using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public bool isActive;
    public List<Text> inputTypeText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetActive(bool _bool) {
        if (isActive != _bool) {
            switch (isActive)
            {
                case true:
                    Time.timeScale = 0.0f;
                    print("set time to 0.0f");
                    break;
                case false:
                    Time.timeScale = 1.0f;
                    print("Set time to 1.0f");
                    break;
            }
        }
    }

    //Check all the inputs for each player and do a thing based on that.
}

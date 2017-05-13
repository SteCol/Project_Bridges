using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerSettings : MonoBehaviour {

    [Header("Sliders")]
    public List<Slider> sliders;
    public List<Text> num;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateText() {
        for (int i = 0; i < sliders.Count; i++) {
            num[i].text = sliders[i].value.ToString();
        }
    }
}

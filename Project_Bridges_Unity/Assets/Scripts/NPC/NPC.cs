using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public List<Node> nodes = new List<Node>();

    public bool generate;

    public int weight;
    public int leaderIndex;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (generate) {
            foreach (Node n in nodes) {
                StartCoroutine(n.MoveForward());
            }
            generate = false;
        } 
	}
}

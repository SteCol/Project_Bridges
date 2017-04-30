//BASED ON https://forum.unity3d.com/threads/in-game-snap-to-grid.77029/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour {

    public bool snap;

    void Start() {
        Snap();
    }

    void FixedUpdate() {
        if (snap) {
            SnapAll();
            snap = false;
        }
    }

    public void Snap() {
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));
    }

    public void SnapAll() {
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("Block")) {
            Vector3 currentPos = b.transform.position;
            b.transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));
        }
    }
}

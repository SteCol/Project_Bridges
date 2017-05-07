using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBounds : MonoBehaviour {
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            col.transform.position = new Vector3(0, 0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public Transform tempTransform;

    void Start() {
        tempTransform = this.transform;
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target

        tempTransform.LookAt(target);

        this.transform.eulerAngles = new Vector3(tempTransform.eulerAngles.x + offset.x, tempTransform.eulerAngles.y + offset.y, tempTransform.eulerAngles.z + offset.z); 
    }
}

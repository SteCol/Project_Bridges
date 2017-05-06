using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matcher : MonoBehaviour {

    public Transform target;

	void Update () {
        this.transform.position = target.position;
	}

    public void SetTarget(Transform _tagret) {
        target = _tagret;
    }
}

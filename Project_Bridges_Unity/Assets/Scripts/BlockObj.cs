using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockObj {

    public string obj;
    public GameObject block;

    public BlockObj(string _obj) {
        obj = _obj;
    }
}

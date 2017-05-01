using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockObj {

    public string name;
    public GameObject blockPrefab;
    public GameObject inGameBlock;

    public Material material;

    public BlockObj(string _name, Material _material) {
        name = _name;
        material = _material;
    }

    public BlockObj(string _name, Material _material, GameObject _prefab)
    {
        name = _name;
        material = _material;
        blockPrefab = _prefab;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockObj {

    public string name;
    public GameObject blockPrefab;
    public GameObject inGameBlock;
    public GameObject container;

    public Material material;
    public Material outline;

    public int grabState;
    public bool occupied;

    //Grabstates:
    //0 = grabbable, not touching a player and not being moved
    //1 = grabbable, touching player and not boing moved
    //2 = grabbable, touching player and not being moved
    //3 = not grabbable

    public BlockObj(string _name, Material _material) {
        name = _name;
        material = _material;
    }

    public BlockObj(string _name, Material _material, Material _outline)
    {
        name = _name;
        material = _material;
        outline = _outline;
    }

    public BlockObj(string _name, Material _material, GameObject _prefab)
    {
        name = _name;
        material = _material;
        blockPrefab = _prefab;
    }

    public void MakeParent(Transform transform) {
        inGameBlock.transform.parent = transform;
    }

    public void Snap()
    {
        Vector3 currentPos = inGameBlock.transform.position;
        inGameBlock.transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));
        Debug.Log("Snapped " + name + " from " + currentPos + " to" + inGameBlock.transform.position + ".");
    }
}

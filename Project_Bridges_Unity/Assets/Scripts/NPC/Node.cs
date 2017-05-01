using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public GameObject gameobject;
    public Vector3 position;
    public List<Node> nodes;

    public Node(GameObject _gameobject) {
        gameobject = _gameobject;
        position = gameobject.transform.position;
    }
}

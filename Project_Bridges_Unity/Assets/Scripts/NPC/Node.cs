using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{

    public int index;
    public int iteration;
    public int parent;
    public int fromIteration;


    public GameObject linkedNode;

    public Node(GameObject _linkedNode, int _index, int _iteration, int _parent, int _froIteration)
    {
        linkedNode = _linkedNode;
        index = _index;
        parent = _parent;
        iteration = _iteration;
        fromIteration = _iteration;
    }
}

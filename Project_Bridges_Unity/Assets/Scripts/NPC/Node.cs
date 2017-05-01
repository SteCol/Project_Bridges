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

    public IEnumerator MoveForward() {
        Debug.Log(Time.deltaTime + " Node is moving");
        yield return new WaitForSeconds(0.5f);
        Debug.Log(Time.deltaTime + "Node finished waiting");

        Debug.Log(Time.deltaTime + "Node finished moving");
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public GameObject copy;
    public List<Node> nodes;

    public bool generate;

    public int weight;
    public int leaderIndex;

    void Update() {
        if (generate) {
            foreach(GameObject l in GameObject.FindGameObjectsWithTag("Leader"))
            {
                Destroy(l);
            }
            GameObject node = Instantiate(copy, this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("NPC").transform);
            node.name = "Node_";
            StartCoroutine(CreateList());
            generate = false;
        } 
	}

    IEnumerator CreateList() {
        print("Waiting on list");
        yield return new WaitForSeconds(3.0f);
        print("Wait done");

        foreach (Node n in nodes) {
            foreach (Node _n in nodes)
            {
                if (n.parent == _n.index) {
                    print(" match between " + n.linkedNode.name + " & " + _n.linkedNode.name);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject copy;
    public List<Node> nodes;

    public bool generate;

    public int weight;
    public int leaderIndex;

    public List<GameObject> path;
    public GameObject trailObj;

    void Update()
    {
        if (generate)
        {
            foreach (GameObject l in GameObject.FindGameObjectsWithTag("Leader"))
            {
                Destroy(l);
            }
            GameObject node = Instantiate(copy, this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("NPC").transform);
            node.name = "Node_";
            StartCoroutine(iCreatePath());
            generate = false;
        }
    }

    IEnumerator iCreateList()
    {
        print("Waiting on list");
        yield return new WaitForSeconds(3.0f);
        print("Wait done");

        foreach (Node n in nodes)
        {
            foreach (Node _n in nodes)
            {
                if (n.parent == _n.index)
                {
                    print(" match between " + n.linkedNode.name + " & " + _n.linkedNode.name);
                }
            }
        }

    }


    IEnumerator iCreatePath()
    {
        print("Waiting on path");
        yield return new WaitForSeconds(1.0f);
        print("Wait done");

        //Find the longuest path.
        GameObject furthersLeader = null;
        foreach (GameObject n in GameObject.FindGameObjectsWithTag("Leader"))
        {
            if (furthersLeader == null)
            {
                furthersLeader = n;
            }

            if (n.GetComponent<Leader>().ints.Count > furthersLeader.GetComponent<Leader>().ints.Count)
            {
                furthersLeader = n;
            }
        }

        //Compare paths with others to find hierarchy.
        foreach (GameObject n in GameObject.FindGameObjectsWithTag("Leader"))
        {
            int checkValue = 0;

            for (int i = 0; i < n.GetComponent<Leader>().ints.Count; i++)
            {
                if (n.GetComponent<Leader>().ints[i] == furthersLeader.GetComponent<Leader>().ints[i] && path.Contains(n) == false)
                {
                    checkValue++;
                }
            }

            print(checkValue + " - " + n.GetComponent<Leader>().ints.Count);
            if (checkValue == n.GetComponent<Leader>().ints.Count)
            {
                path.Add(n);
            }
        }

        //Colour
        foreach (GameObject n in path)
        {
            yield return new WaitForSeconds(0.05f);
            n.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        MoveNPC();
    }

    void MoveNPC()
    {
        trailObj.transform.position = this.transform.position;
        this.transform.position = path[1].transform.position;
        path.Clear();
        generate = true;
    }
}

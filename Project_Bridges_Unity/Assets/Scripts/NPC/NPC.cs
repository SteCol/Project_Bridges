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
    public List<GameObject> trailObj;

    void Update()
    {
        if (generate)
        {
            path.Clear();
            foreach (GameObject l in GameObject.FindGameObjectsWithTag("Leader"))
            {
                Destroy(l);
            }
            GameObject node = Instantiate(copy, transform.position, Quaternion.identity, transform);
            node.name = "Node_";
            //node.tag = "Trail";
            StartCoroutine(iGeneratePath());
            generate = false;
        }
    }

    #region Generate the path
    IEnumerator iGeneratePath()
    {
        //print("Waiting on path");
        yield return new WaitForSeconds(1.0f);
        //print("Wait done");

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

            //print(checkValue + " - " + n.GetComponent<Leader>().ints.Count);
            if (checkValue == n.GetComponent<Leader>().ints.Count)
            {
                path.Add(n);
            }
        }

        //Colour
        foreach (GameObject n in path)
        {
            yield return new WaitForSeconds(0.025f);
            n.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        yield return new WaitForSeconds(1.0f);
        MoveNPC();
    }
    #endregion

    #region Move the NPC
    void MoveNPC()
    {
        //trailObj.transform.position = this.transform.position;
        MoveTrail();
        if (path.Count > 1)
        {
            this.transform.position = path[1].transform.position;
            generate = true;
        }
        else
        {
            print("DEAD");
        }
    }

    void MoveTrail() {
        for (int i = trailObj.Count-1; i > 0; i--) {
            trailObj[i].transform.position = trailObj[i - 1].transform.position;
        }
        trailObj[0].transform.position = this.transform.position;
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Setup")]
    public GameController gameController;
    public GameObject copy;
    public List<Node> nodes;
    public bool generate;
    public float generationSpeed;
    public float spawnDepth;
    public List<GameObject> toRespawn;
    public List<Vector3> spawnPoint;

    [Header("Trail")]
    public List<GameObject> path;
    public List<GameObject> trailObj;

    void Start() {
        SetSpawnPoints();
        if (gameController == null)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void SetSpawnPoints()
    {
        spawnPoint.Add(this.transform.position);
        toRespawn.Add(this.gameObject);
        foreach (GameObject t in trailObj) {
            spawnPoint.Add(t.transform.position);
            toRespawn.Add(t);
        }
    }

    void Update()
    {
        if (generate)
        {
            SpawnFirstNode();
        }
    }

    #region Generate the path
    void SpawnFirstNode()
    {
        path.Clear();
        foreach (GameObject l in GameObject.FindGameObjectsWithTag("Leader"))
        {
            Destroy(l);
        }

        Vector3 spawnPos = new Vector3 (transform.position.x, transform.position.y - spawnDepth, transform.position.z);
        GameObject node = Instantiate(copy, spawnPos, Quaternion.identity, transform);
        node.name = "Node_";
        //node.tag = "Trail";
        StartCoroutine(iGeneratePath());
        generate = false;
    }

    IEnumerator iGeneratePath()
    {
        Debug.Log("Generating Path " + Time.time);
        float storeTime = Time.time;
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

        Debug.Log("Finished Generating Path " + Time.time + " [" + (Time.time - storeTime) + "].");

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
            Vector3 nodePos = path[1].transform.position;
            Vector3 spawnPos = new Vector3(nodePos.x, nodePos.y + spawnDepth, nodePos.z);
            this.transform.position = spawnPos;

            generate = true;
        }
        else
        {
            //No path means DEATH
            print("DEAD");
            Respawn();
        }
    }

    void MoveTrail()
    {
        for (int i = trailObj.Count - 1; i > 0; i--)
        {
            trailObj[i].transform.position = trailObj[i - 1].transform.position;
        }
        trailObj[0].transform.position = this.transform.position;
    }

    void Respawn() {
        if (gameController.currentLives > 0)
        {
            gameController.UpdateLives(-1);
            for (int i = 0; i < toRespawn.Count; i++)
            {
                toRespawn[i].transform.position = spawnPoint[i];
            }
            generate = true;
        }
        else {
            gameController.GameOver();
            print("GAME OVER");
        }
    }

    #endregion
}

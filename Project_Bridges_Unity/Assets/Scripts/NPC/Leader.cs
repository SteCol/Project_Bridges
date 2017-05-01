using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    public int weight;
    public Vector3 rayOne, rayTwo;
    public List<Vector3> toGenerateFrom;

    public NPC npc;
    public GameObject copy;

    void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>();
        DoThing();
    }

    void Update()
    {
        //DoThing();
    }

    void DoThing()
    {
        Vector3 rayOnePos = this.transform.position + rayOne;

        RaycastHit hit;
        Debug.DrawRay(rayOnePos, -transform.up, Color.blue);

        bool rayOneBool = false;

        if (Physics.Raycast(rayOnePos, -transform.up, out hit, 1.0f))
        {
            if (hit.transform.gameObject.tag == "Block" && hit.transform.gameObject.tag != "Leader")
            {
                rayOneBool = true;
                GenerateNew();
            }
        }

        if (rayOneBool)
        {
            print("Clear");
        }
    }

    void GenerateNew()
    {
        print("Starting GenerateNew()");
        foreach (Vector3 pos in toGenerateFrom)
        {

            RaycastHit hit;
            Vector3 rayPos = transform.position + pos + new Vector3(0, 1, 0);
            Vector3 spawnPos = transform.position + pos;

            if (Physics.Raycast(rayPos, -transform.up, out hit, 2.0f))
            {
                if (hit.transform.gameObject.tag == "Block")
                {
                    weight = npc.weight;
                    Debug.DrawRay(rayPos, -transform.up, Color.green, 5.0f);
                    GameObject node = Instantiate(copy, spawnPos, Quaternion.identity, GameObject.FindGameObjectWithTag("NPC").transform);
                    copy.name = npc.leaderIndex + " _Node_" + weight.ToString() ;
                    npc.leaderIndex++;
                }
                else
                {
                    Debug.DrawRay(rayPos, -transform.up, Color.red, 5.0f);
                }
            }
        }
        npc.weight++;
    }
}

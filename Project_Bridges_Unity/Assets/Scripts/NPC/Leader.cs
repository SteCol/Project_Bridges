using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [Header("Stuff")]
    public int index;
    public int fromIteration;
    public Vector3 rayOne, rayTwo;
    public List<Vector3> toGenerateFrom;

    [Header("More Stuff")]
    public NPC npc;
    public GameObject copy;

    [Header("Important Stuff")]
    public List<int> ints;

    void Start()
    {
        print("I GOT SPAWNED YAY");
        npc = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>();
        DoThing();
        CalculateInts();
    }

    void Update()
    {
        //DoThing();
    }

    void CalculateInts() {
        ints.Clear();
        string str = this.name;
        string[] splitString = str.Split('.');
        Debug.Log(str + " split into " + splitString.Length);
        for (int i =1; i < splitString.Length; i++) {
            ints.Add(int.Parse(splitString[i]));
        }

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
                StartCoroutine(GenerateNew());
            }
        }

        if (rayOneBool)
        {
            print("Clear");
        }
    }

    IEnumerator GenerateNew()
    {
        int iteration = 0;
        float genSpeed = 0.01f;
        print("Starting GenerateNew()");
        foreach (Vector3 pos in toGenerateFrom)
        {
            iteration++;
            RaycastHit hit;
            Vector3 rayPos = transform.position + pos + new Vector3(0, 1, 0);
            Vector3 spawnPos = transform.position + pos;

            Debug.DrawRay(rayPos, -transform.up, Color.blue, genSpeed);
            if (Physics.Raycast(rayPos, -transform.up, out hit, 2.0f))
            {
                if (hit.transform.gameObject.tag == "Block")
                {
                    Debug.DrawRay(rayPos, -transform.up, Color.green, genSpeed);
                    GameObject node = Instantiate(copy, spawnPos, Quaternion.identity, GameObject.FindGameObjectWithTag("NPC").transform);
                    //GameObject node = Instantiate(copy, spawnPos, Quaternion.identity, transform);
                    //node.transform.parent = this.transform;
                    node.GetComponent<Leader>().index = index + 1;
                    node.GetComponent<Leader>().fromIteration = iteration;
                    node.name = this.name + "." + iteration;
                    //node.name = "Node_" + node.GetComponent<Leader>().index.ToString("000") + "_[i: " + iteration + "]_[parent: " + index + ", " + node.GetComponent<Leader>().fromIteration + "]";
                    //npc.nodes.Add(new Node(node.gameObject, node.GetComponent<Leader>().index, iteration, index, iteration));
                }
                else
                {
                    Debug.DrawRay(rayPos, -transform.up, Color.red, genSpeed);
                }
            }
            yield return new WaitForSeconds(genSpeed);
        }
    }

    void MoveNPC() {

    }
}

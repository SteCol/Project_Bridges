using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupyBlocks : MonoBehaviour
{
    [Header("Setup")]
    public PlayerSetup playerSetup;
    public bool canOccupy;

    void Start()
    {
        if (playerSetup == null)
        {
            playerSetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSetup>();
        }
    }

    void Update()
    {
        if (canOccupy)
        {
            CheckOccupy();
        }
    }

    void CheckOccupy()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.up, Color.blue);

        //bool rayOneBool = false;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 1.0f))
        {
            if (hit.transform.gameObject.tag == "Block")
            {
                foreach (Player p in playerSetup.players)
                    foreach (BlockObj b in p.blocks)
                        if (b.inGameBlock == hit.transform.gameObject)
                        {
                            b.occupied = true;
                        }
                        else {
                            b.occupied = false;
                        }
            }
        }
    }
}

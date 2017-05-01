using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    PlayerSetup playerSetup;

    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSetup>();
    }

    void OnTriggerStay(Collider col)
    {
        DoChecks(col, 1);
    }

    void OnTriggerExit(Collider col)
    {
        DoChecks(col, 0);
    }

    void DoChecks(Collider col, int i) {
        if (col.tag == "Block")
        {
            foreach (Player p in playerSetup.players)
            {
                if (p.playerinGame == this.gameObject)
                {
                    foreach (BlockObj b in p.blocks)
                    {
                        if (b.inGameBlock == col.gameObject)
                        {
                            b.grabState = i;
                        }
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    PlayerSetup playerSetup;
    public bool moving;

    [Header("CLaw")]
    public SpriteRenderer sr;
    //public Sprite openClaw;
    //public Sprite closedClaw;
    public Animator clawAnimator;

    void Start()
    {
        playerSetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSetup>();
        sr.color = this.gameObject.GetComponent<MeshRenderer>().material.color;
    }

    #region Block Check
    void OnTriggerEnter(Collider col)
    {
        DoChecks(col, 1);
    }

    void OnTriggerExit(Collider col)
    {
        if (moving == false)
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
    #endregion

    #region Claw Animation
    public void AnimateClaw(string _state)
    {
        if (_state == "Open")
        {
            //sr.sprite = openClaw;
            //clawAnimator.SetBool("Grab", );
        }
        if (_state == "Closed")
        {
            //sr.sprite = closedClaw;
        }
    }

    public void AnimateClaw(bool _state)
    {
            clawAnimator.SetBool("Grab", _state);
    }
    #endregion
}

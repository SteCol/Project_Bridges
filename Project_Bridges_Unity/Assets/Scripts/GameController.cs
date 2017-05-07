using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Setup")]
    public PlayerSetup playerSetup;
    public GameObject containerObject;

    public bool generate;

    public Transform spawnPos;

    [Header("Misc")]
    public bool lockCursor;

    [Header("Prefabs")]
    public GameObject scaffolding;

    void Start()
    {
        if (playerSetup == null)
        {
            playerSetup = this.GetComponent<PlayerSetup>();
        }
        GeneratePlayers();
    }

    void FixedUpdate()
    {
        if (generate)
        {
            GeneratePlayers();
            generate = false;
        }

        MoveBlocks();

        if (Input.GetKeyDown(KeyCode.L))
            lockCursor = true;

        if (lockCursor) {
            Cursor.lockState = CursorLockMode.Locked;
            lockCursor = false;
        }
    }

    #region Block Interaction Control
    void MoveBlocks()
    {
        foreach (Player p in playerSetup.players)
        {
            /*
            if (p.action)
            {
                p.playerinGame.GetComponent<PlayerObject>().AnimateClaw("Closed");
            }
            else {
                p.playerinGame.GetComponent<PlayerObject>().AnimateClaw("Open");
            }
            */
            p.inGamePlayer.GetComponent<PlayerObject>().AnimateClaw(p.action);

            foreach (BlockObj b in p.blocks)
            {
                if (b.occupied == false)
                {
                    if (p.action == false && b.grabState == 1)
                    {
                        b.UpdateOutline();
                    }
                    else if (p.action == true && b.grabState == 1)
                    {
                        b.grabState = 2;
                        b.UpdateOutline();
                    }
                    else if (p.action == true && b.grabState == 2 && p.busy == false)
                    {
                        p.inGamePlayer.GetComponent<PlayerObject>().moving = true;
                        b.MakeParent(p.inGamePlayer.transform);
                        p.busy = true;
                    }
                    else if (p.action == false && b.grabState == 2)
                    {
                        b.MakeParent(b.container.transform);
                        p.inGamePlayer.GetComponent<PlayerObject>().moving = false;
                        b.Snap();
                        b.grabState = 0;
                        p.busy = false;
                        b.UpdateOutline();

                    }
                    else if (p.action == false && b.grabState == 0)
                    {
                        b.UpdateOutline();
                    }
                }
            }
        }
    }

    #endregion

    #region Generating the players
    void GeneratePlayers()
    {
        Debug.Log("STARTING GENERATION");

        spawnPos.position = this.transform.position;

        //Remove all previous generations
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("PlayerContainer"))
        {
            Destroy(g);
        }

        //Make an empty GameObject for all the players.
        GameObject playerContainer = Instantiate(containerObject);
        playerContainer.name = "Player Container";
        playerContainer.tag = "PlayerContainer";
        playerContainer.transform.position = spawnPos.position;

        foreach (Player p in playerSetup.players)
        {
            //make an empty GameObject per player, to hold the player object and the blocks container.
            GameObject container = Instantiate(containerObject);
            container.name = p.name + " Container";
            container.transform.parent = playerContainer.transform;

            UpdateSpawnPos();
            //Generate the player avatar.
            GameObject player = Instantiate(playerSetup.player);
            player.name = p.name;
            player.transform.parent = container.transform;
            player.GetComponentInChildren<Renderer>().material = p.material;
            p.inGamePlayer = player;
            player.transform.position = spawnPos.position;

            //Give the player scaffolding.
            GameObject scaffold = Instantiate(scaffolding);
            scaffold.GetComponent<Matcher>().SetTarget(player.transform);
            scaffold.GetComponentInChildren<MeshRenderer>().material.color = player.gameObject.GetComponent<MeshRenderer>().material.color;
            scaffold.transform.parent = container.transform;

            //Make an empty GameObject to hold the blocks.
            GameObject blocks = Instantiate(containerObject);
            blocks.name = "Blocks";
            blocks.transform.parent = container.transform;

            foreach (BlockObj b in p.blocks)
            {
                UpdateSpawnPos();
                //Generate the blocks.
                GameObject block = Instantiate(b.blockPrefab);
                block.name = p.name + "/" + b.name + "/" + block.GetComponent<MeshFilter>().name;
                block.transform.parent = blocks.transform;
                b.container = blocks;

                //Making an array to set the MeshRenderer materials to.
                Material[] blockMaterials = new Material[2]; 
                blockMaterials[0] = b.material;
                blockMaterials[1] = b.outline;

                block.GetComponent<Renderer>().materials = blockMaterials;

                b.inGameBlock = block;
                block.transform.position = spawnPos.position;

            }
        }
        Debug.Log("FINISHED GENERATION");
    }

    void UpdateSpawnPos()
    {
        spawnPos.position = new Vector3(spawnPos.position.x + 3, spawnPos.position.y, spawnPos.position.z);
    }

    void GiveScaffolding(GameObject _player) {
        

    }
    #endregion
}

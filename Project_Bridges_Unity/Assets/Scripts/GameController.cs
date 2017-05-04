using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerSetup playerSetup;
    public GameObject containerObject;

    public bool generate;

    public Transform spawnPos;

    [Header("Misc")]
    public bool lockCursor;

    void Start()
    {
        if (playerSetup == null)
        {
            playerSetup = this.GetComponent<PlayerSetup>();
        }
        StartGame();
    }

    void FixedUpdate()
    {
        if (generate)
        {
            StartGame();
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

    void UpdateSpawnPos()
    {
        spawnPos.position = new Vector3(spawnPos.position.x + 3, spawnPos.position.y, spawnPos.position.z);
    }

    void MoveBlocks()
    {
        foreach (Player p in playerSetup.players)
        {
            foreach (BlockObj b in p.blocks)
            {
                if (p.action == true && b.grabState == 1)
                {
                    b.grabState = 2;
                }
                else if (p.action == true && b.grabState == 2)
                {
                    p.playerinGame.GetComponent<PlayerObject>().moving = true;
                    b.MakeParent(p.playerinGame.transform);
                }
                else if (p.action == false && b.grabState == 2)
                {
                    b.MakeParent(b.container.transform);
                    p.playerinGame.GetComponent<PlayerObject>().moving = false;
                    b.Snap();
                    b.grabState = 0;
                }
            }
        }
    }



    void StartGame()
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
            player.GetComponent<Renderer>().material = p.material;
            p.playerinGame = player;
            player.transform.position = spawnPos.position;


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

                block.GetComponent<Renderer>().material = b.material;
                b.inGameBlock = block;
                block.transform.position = spawnPos.position;

            }
        }
        Debug.Log("FINISHED GENERATION");
    }
}

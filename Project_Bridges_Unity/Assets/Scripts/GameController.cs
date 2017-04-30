using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public PlayerSetup playerSetup;

    void Start () {
        if (playerSetup == null) {
            playerSetup = this.GetComponent<PlayerSetup>();
        }
        StartGame();
	}
	
    void StartGame() {
        Debug.Log("STARTING GENERATION");

        //Make an empty GameObject for all the players
        GameObject playerContainer = Instantiate(new GameObject());
        playerContainer.name = "Player Container";

        foreach (Player p in playerSetup.players) {
            Debug.Log("       GENERATING PLAYER: " + p.name);

            //make an empty GameObject per player, to hold the player object and the blocks container
            GameObject container = Instantiate(new GameObject());
            container.name = p.name + " Container";
            container.transform.parent = playerContainer.transform;

            GameObject player = Instantiate(playerSetup.player);
            player.transform.parent = container.transform;
            player.name = p.name;
            player.GetComponent<Renderer>().material = p.material;

            //Make an empty GameObject to hold the blocks
            GameObject blocks = Instantiate(new GameObject());
            blocks.name = p.name + " Blocks";
            blocks.transform.parent = container.transform;

            foreach (BlockObj b in p.blocks) {
                Debug.Log("              GENERATING BLOCK: " + b.name);

                GameObject block = Instantiate(b.block);
                block.transform.parent = blocks.transform;
                block.name = p.name + "/" + b.name + "/" + block.GetComponent<MeshFilter>().name;
                block.GetComponent<Renderer>().material = b.material;
            }
        }
    }

   
}

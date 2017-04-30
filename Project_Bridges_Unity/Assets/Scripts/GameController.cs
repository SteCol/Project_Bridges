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

        //Make an empty GameObject for all the players.
        GameObject playerContainer = Instantiate(new GameObject("Player Container"));

        foreach (Player p in playerSetup.players) {
            //make an empty GameObject per player, to hold the player object and the blocks container.
            GameObject container = Instantiate(new GameObject(p.name + " Container"));
            container.transform.parent = playerContainer.transform;

            //Generate the player avatar.
            GameObject player = Instantiate(playerSetup.player);
            player.name = p.name;
            player.transform.parent = container.transform;
            player.GetComponent<Renderer>().material = p.material;

            //Make an empty GameObject to hold the blocks.
            GameObject blocks = Instantiate(new GameObject(p.name + " Blocks"));
            blocks.transform.parent = container.transform;

            foreach (BlockObj b in p.blocks) {
                //Generate the blocks.
                GameObject block = Instantiate(b.block);
                block.name = p.name + "/" + b.name + "/" + block.GetComponent<MeshFilter>().name;
                block.transform.parent = blocks.transform;
                block.GetComponent<Renderer>().material = b.material;
            }
        }
        Debug.Log("FINISHED GENERATION");
    }
}

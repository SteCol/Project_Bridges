using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public PlayerSetup playerSetup;

    void Start () {
        if (playerSetup == null)
        {
            playerSetup = this.GetComponent<PlayerSetup>();
        }
    }
	
	void Update () {
        foreach (Player p in playerSetup.players) {
            p.player.transform.Translate(new Vector3(Input.GetAxis(p.horizontalInput), 0,Input.GetAxis(p.verticalInput)));
        }
	}
}

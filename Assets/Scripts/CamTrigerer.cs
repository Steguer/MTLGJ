using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; //This allows the IComparable Interface

public class CamTrigerer : MonoBehaviour {
	int nbrPlayers = 4;

    GameObject camera;
	public GameObject beforeTile;
	public GameObject afterTile;
	private int players = 0;
	private bool enaSwitch = true;
    public GameObject cameraAnchor;

    /* 0 = top
     * 1 = right
     * 2 = down
     * 3 = left
     */
    public int position = 0;

	void Start () 
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

    void OnTriggerExit2D(Collider2D collider)
    {	
		Physics2D.IgnoreLayerCollision(9, 9, false);
		if (collider.gameObject.tag != "Player")
			return;
		players--;
    }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag != "Player")
			return;
		//beforeTile.collider2D.isTrigger = false;
		Physics2D.IgnoreLayerCollision(9, 9);
		players++;

		if(players >= nbrPlayers && enaSwitch) {
            camera.GetComponent<MoveCam>().moveTo(cameraAnchor);
			beforeTile.collider2D.isTrigger = false;
			afterTile.collider2D.isTrigger = true;
			enaSwitch = false;
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if(players >= nbrPlayers) {
			//collider.gameObject.GetComponent<Playermovement>().movementSpeed = 5.0f;
			afterTile.collider2D.isTrigger = true;
		}
	}
}

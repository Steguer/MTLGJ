using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; //This allows the IComparable Interface

public class CamTrigerer : MonoBehaviour {
	int nbrPlayers = 2;

    GameObject camera;
	public GameObject beforeTile;
	public GameObject afterTile;
	private int players = 0;
	private bool enaSwitch = true;

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
			if (position == 0)
			{
				camera.GetComponent<MoveCam>().moveUp();
				this.position = 2;
			}
			else if (position == 1)
			{
				camera.GetComponent<MoveCam>().moveRight();
				this.position = 3;
			}
			else if (position == 2)
			{
				camera.GetComponent<MoveCam>().moveDown();
				this.position = 0;
			}
			else if (position == 3)
			{
				camera.GetComponent<MoveCam>().moveLeft();
				this.position = 1;
			}
			else
				Debug.Log("Invalid cam trigger 'position' variable");

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

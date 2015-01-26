using UnityEngine;
using System.Collections;

public class RoomEndDoorScript : MonoBehaviour {
	int nbrPlayers = 2;
	public int linkedRoom;
	
	int players = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{	
		if (collider.gameObject.tag != "Player")
			return;
		Physics2D.IgnoreLayerCollision(9, 9, false);
		players--;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag != "Player")
			return;
		//beforeTile.collider2D.isTrigger = false;
		Physics2D.IgnoreLayerCollision(9, 9);
		players++;
		checkPlayersNbr ();
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		checkPlayersNbr ();
	}
	
	void checkPlayersNbr ()
	{
		if(players >= nbrPlayers) {
			GameObject levelManager = GameObject.FindGameObjectWithTag ("LevelManager");
			levelManager.GetComponent<LevelManager>().changeRoom(this.linkedRoom);
		}
	}
}

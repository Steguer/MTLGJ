using UnityEngine;
using System.Collections;

public class LevelEndDoorScript : MonoBehaviour {
	int nbrPlayers = 4;
	public string nextLevelName = "";
	
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
			if(nextLevelName != "")
				Application.LoadLevel (nextLevelName);
			players = 0;
		}
	}
}

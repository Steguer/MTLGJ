using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovableBlockButton : MovableScript {
	int nbrPusher = 0;
	public int pushThreshold = 2;	//Nombre de fois qu'il faut appuyer sur action par seconde chacun
	bool canMove = false;
	Vector2 previousPosition;
	float lastSynchro = 0;
	public float deltaSynchro = 0.7f;
	private List<GameObject> interactivePlayers;
	private List<int> pushCount;

	public int neededPusher = 2;

	void Start () {
		previousPosition = transform.position;
		pushCount = new List<int> (4);
		for(int i = 0; i < 4; i++)
			pushCount.Add( 0 );
	}

	void Update () {

        if (isFalling && (transform.localScale.x > 0f))
        {
            transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
            transform.position = Vector3.MoveTowards(transform.position, fallingPosition, movingTowardsTrapSpeed * Time.deltaTime);
        }

		checkingSynchro ();

		if(!canMove) 
		{
			transform.position = previousPosition;
			return;
		}

		Vector3 newPos = transform.position;
		newPos.x = (previousPosition.x + transform.position.x) / 2;
		newPos.y = (previousPosition.y + transform.position.y) / 2;
		transform.position = newPos;

		previousPosition = transform.position;
	}

	/*void checkNbrPusher ()
	{
		if (nbrPusher >= neededPusher)
			canMove = true;
		else
			canMove = false;
		Debug.Log ("Pusher "+nbrPusher);
	}*/

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag != "Player")
			return;

		//	coll.gameObject.SendMessage("setPushing", true);
		//interactivePlayers.Add(coll.gameObject);
		coll.gameObject.GetComponent<Playermovement> ().addActionListener (this.gameObject);

		nbrPusher++;
		//checkNbrPusher ();

		Debug.Log ("Player enter");
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag != "Player")
			return;

		//	coll.gameObject.SendMessage("setPushing", false);
		//interactivePlayers.Remove(coll.gameObject);
		coll.gameObject.GetComponent<Playermovement> ().removeActionListener (this.gameObject);

		if(nbrPusher > 0)
			nbrPusher--;
		//checkNbrPusher ();
		
		Debug.Log ("Player leave");
	}

	void checkingSynchro ()
	{

		if(nbrPusher == 0) {
			lastSynchro = Time.fixedTime;
			return;
		}
		
		float delta = Time.fixedTime - lastSynchro;
		
		if( delta > deltaSynchro )
		{
			int completeNbr = 0;
			for(int i = 0; i < pushCount.Count; i++) {
				if(pushCount[i] > pushThreshold) {
					completeNbr++;
				}
				pushCount[i] = 0;
			}
			if(completeNbr >= neededPusher)
				canMove = true;
			else
				canMove = false;
			//Debug.Log ("delta : " + delta);
			lastSynchro = Time.fixedTime;
		}
	}
	/*void checkingButton () 
	{
		foreach(GameObject player in interactivePlayers) {

		}
	}*/

	public void ActionPressed (int player)
	{
		Debug.Log ("plyaer " + player);
		pushCount[player-1]++;
	}
}

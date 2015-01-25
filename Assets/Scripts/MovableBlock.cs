using UnityEngine;
using System.Collections;

public class MovableBlock : MovableScript {
	int nbrPusher = 0;
	bool canMove = false;
	Vector2 previousPosition;
	float lastSynchro = 0;
	float deltaSynchro = 0.3f;

	public int neededPusher = 2;
	public bool checkingSynchro = true;

	void Start () {
		previousPosition = transform.position;
	}

	void Update () {

        if (isFalling && (transform.localScale.x > 0f))
        {
            transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
            transform.position = Vector3.MoveTowards(transform.position, fallingPosition, movingTowardsTrapSpeed * Time.deltaTime);
        }

		checkSynchro ();

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

	void checkNbrPusher ()
	{
		if (nbrPusher >= neededPusher)
			canMove = true;
		else
			canMove = false;
		Debug.Log ("Pusher "+nbrPusher);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag != "Player")
			return;

		//	coll.gameObject.SendMessage("setPushing", true);

		nbrPusher++;
		checkNbrPusher ();

		Debug.Log ("Player enter");
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag != "Player")
			return;

		//	coll.gameObject.SendMessage("setPushing", false);

		nbrPusher --;
		checkNbrPusher ();
		
		Debug.Log ("Player leave");
	}

	void checkSynchro ()
	{
		if(!checkingSynchro)
			return;

		if(nbrPusher == 0) {
			lastSynchro = Time.fixedTime;
			return;
		}
		
		float delta = Time.fixedTime - lastSynchro;
		
		if( delta > deltaSynchro )
		{
			//Debug.Log ("delta : " + delta);
			lastSynchro = Time.fixedTime;
			nbrPusher = 0;
			canMove = false;
		}
	}
}

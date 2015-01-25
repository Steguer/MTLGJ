using UnityEngine;
using System.Collections;

public class MovableBlock : MonoBehaviour {
	int nbrPusher = 0;
	bool canMove = false;
	Vector2 previousPosition;

	public int neededPusher = 2;

	void Start () {
		previousPosition = transform.position;
	}

	void Update () {
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
}

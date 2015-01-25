using UnityEngine;
using System.Collections;

public class MovableBlock : MovableScript {
	int nbrPusher = 0;
	public bool canMove = false;
	Vector2 previousPosition;
    public bool destroyWhenDone = false;
    Vector3 origin;
    Vector3 scale;

	public int neededPusher = 2;

	void Start () {
		previousPosition = transform.position;
        origin = transform.position;
        scale = transform.localScale;
	}

	void Update () {

        if (isFalling && (transform.localScale.x > 0f))
        {
            transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
            transform.position = Vector3.MoveTowards(transform.position, fallingPosition, movingTowardsTrapSpeed * Time.deltaTime);
            destroyWhenDone = true;
        }
        else if (destroyWhenDone)
            Destroy(this.gameObject);

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

    void reset()
    {
        transform.position = origin;
        transform.localScale = scale;

    }

}

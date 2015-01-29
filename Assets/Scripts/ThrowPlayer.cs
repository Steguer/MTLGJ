using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowPlayer : MonoBehaviour {
	private List<bool> pusherList;
	private Vector3 previousPosition;
	private Vector3 nextPosition;
	private int playersNbr = 4;
	private float lastSynchro = 0;

	public bool isFlying = false;
	public float speed = 10f;
	public float deltaSynchro = 0.4f;

	// Use this for initialization
	void Start () {
		pusherList = new List<bool>(playersNbr);
		for(int i=0; i<playersNbr; i++) {
			pusherList.Add(false);
		}
		isFlying = false;
		nextPosition = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFlying && (Vector3.Distance(nextPosition, gameObject.transform.position) > 0)) {
			transform.position = Vector3.MoveTowards(transform.position, nextPosition , speed * Time.deltaTime);
		}
		else {
			isFlying = false;
		}
		checkingSynchro ();

		this.checkWellFlying ();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag != "Player")
			return;

		coll.gameObject.GetComponent<Playermovement> ().addActionListener (this.gameObject);
		//Debug.Log("Add to list");
	}

	void OnTriggerExit2D(Collider2D coll) {
		if(coll.gameObject.tag != "Player")
			return;

		int playerId = coll.gameObject.GetComponent<Playermovement> ().removeActionListener (this.gameObject);
		pusherList[playerId] = false;
		//Debug.Log ("Remove to list");
	}
	
	public void ActionAPressed (int playerId)
	{
		pusherList[playerId] = true;
	}
	
	public void ActionBPressed (int playerId)
	{}

	void OnCollisionStay2D(Collision2D coll) {
		if(!isFlying)
			return;
		if(coll.gameObject.tag == "Hole"
			|| coll.gameObject.tag == "Proximity"
			|| coll.gameObject.tag == "Player")
			return;
		
		isFlying = false;
		Debug.Log ("Tag : "+coll.gameObject.tag);
	}

	void checkWellFlying () {
		if(!isFlying)
			return;
		/*if(previousPosition == transform.position)
		{
			isFlying = false;
		}*/
	}

	void checkingSynchro ()
	{
		int pushersNbr = pusherList.FindAll(x => x == true).Count;
			//if(playersList.FindAll
		if(pushersNbr == 0) {
			lastSynchro = Time.fixedTime;
			return;
		}
		
		float delta = Time.fixedTime - lastSynchro;
		
		if( delta > deltaSynchro )
		{
			throwPlayer(pushersNbr);
			for(int i = 0; i < pusherList.Count; i++)
			{
				pusherList[i] = false;
			}
			pushersNbr = pusherList.FindAll(x => x == true).Count;
			Debug.Log("pusher : "+pushersNbr);
			pushersNbr = 0;
			//Debug.Log ("delta : " + delta);
			lastSynchro = Time.fixedTime;
		}
	}

	void throwPlayer (int power)
	{
        if (!isFlying)
        {
            float value = 2f + (float)power;
            Vector3 tmp;
            int dir = gameObject.GetComponent<Playermovement>().GetComponent<Animator>().GetInteger("direction");
            switch (dir)
            {
                case 1:
                    tmp = new Vector3(0, value, 0);
                    break;
                case 2:
                    tmp = new Vector3(0, -(value), 0);
                    break;
                case 3:
                    tmp = new Vector3(-(value), 0, 0);
                    break;
                case 4:
                    tmp = new Vector3(value, 0, 0);
                    break;
                default:
                    tmp = new Vector3(0, value, 0);
                    break;
            }
            Debug.Log("throw player power : " + value);
            nextPosition = transform.position + tmp;
            isFlying = true;
        }
	}
}
	
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowPlayer : MonoBehaviour {
	private int vilainCount;
	private List<bool> playersList;
	private List<GameObject> throwVictimList;
	private Vector3 previousPosition;
	private Vector3 nextPosition;
	public bool isFlying = false;
	public float speed = 10f;
	public int playersNbr = 4;

	public List<GameObject> ThrowVictimList {
		get {
			return throwVictimList;
		}
	}

	public void IncCount() {
		++vilainCount;
		Debug.Log("throwCount: " + vilainCount);
	}

	// Use this for initialization
	void Start () {
		throwVictimList = new List<GameObject>();
		playersList = new List<bool>(playersNbr);
		for(int i=0; i<playersNbr; i++) {
			playersList.Add(false);
		}
		vilainCount = 0;
		isFlying = false;
		nextPosition = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		if(vilainCount >= 1) {
			Vector3 tmp;
			int dir = gameObject.GetComponent<Playermovement>().GetComponent<Animator>().GetInteger("direction");
			switch (dir) {
			case 1:
				tmp = new Vector3(0, 3.0f, 0);
				break;
			case 2:
				tmp = new Vector3(0, -3.0f, 0);
				break;
			case 3:
				tmp = new Vector3(-3.0f, 0, 0);
				break;
			case 4:
				tmp = new Vector3(3.0f, 0, 0);
				break;
			default: 
				tmp = new Vector3(0, 3.0f, 0);
				break;
			}

			nextPosition = transform.position + tmp;
			isFlying = true;
		}
		if(isFlying && (Vector3.Distance(nextPosition, gameObject.transform.position) > 0)) {
			transform.position = Vector3.MoveTowards(transform.position, nextPosition , speed * Time.deltaTime);
		}
		else {
			isFlying = false;
		}
		vilainCount = 0;

		this.checkWellFlying ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag != "Player")
			return;

		if(collider.gameObject.GetComponent<Playermovement>().player == "1") {
			if(playersList[0] == false) {
				playersList[0] = true;
				throwVictimList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "2") {
			if(playersList[1] == false) {
				playersList[1] = true;
				throwVictimList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "3") {
			if(playersList[2] == false) {
				playersList[2] = true;
				throwVictimList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "4") {
			if(playersList[3] == false) {
				playersList[3] = true;
				throwVictimList.Add(collider.gameObject);
			}
		}
		Debug.Log("Add to list");
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag != "Player")
			return;

		if(collider.gameObject.GetComponent<Playermovement>().player == "1") {
			if(playersList[0] == true) {
				playersList[0] = false;
				throwVictimList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "2") {
			if(playersList[1] == true) {
				playersList[1] = false;
				throwVictimList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "3") {
			if(playersList[2] == true) {
				playersList[2] = false;
				throwVictimList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "4") {
			if(playersList[3] == true) {
				playersList[3] = false;
				throwVictimList.Remove(collider.gameObject);
			}
		}
		Debug.Log ("Remove to list");
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "Hole")
			return;
		isFlying = false;
	}

	void checkWellFlying () {
		if(previousPosition == transform.position)
		{
			isFlying = false;
		}
	}
}

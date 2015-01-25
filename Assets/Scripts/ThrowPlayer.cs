﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowPlayer : MonoBehaviour {
	private int vilainCount;
	private List<bool> playersList;
	private List<GameObject> pusherList;
	private Vector3 previousPosition;
	private Vector3 nextPosition;
	private int playersNbr = 4;
	private float lastSynchro = 0;

	public bool isFlying = false;
	public float speed = 10f;
	public float deltaSynchro = 0.4f;

	public List<GameObject> PusherList {
		get {
			return pusherList;
		}
	}

	public void IncCount() {
		++vilainCount;
		Debug.Log("throwCount: " + vilainCount);
	}

	// Use this for initialization
	void Start () {
		pusherList = new List<GameObject>();
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
		if(isFlying && (Vector3.Distance(nextPosition, gameObject.transform.position) > 0)) {
			transform.position = Vector3.MoveTowards(transform.position, nextPosition , speed * Time.deltaTime);
		}
		else {
			isFlying = false;
		}
		checkingSynchro ();

		this.checkWellFlying ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag != "Player")
			return;

		if(collider.gameObject.GetComponent<Playermovement>().player == "1") {
			if(playersList[0] == false) {
				playersList[0] = true;
				pusherList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "2") {
			if(playersList[1] == false) {
				playersList[1] = true;
				pusherList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "3") {
			if(playersList[2] == false) {
				playersList[2] = true;
				pusherList.Add(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "4") {
			if(playersList[3] == false) {
				playersList[3] = true;
				pusherList.Add(collider.gameObject);
			}
		}
		//Debug.Log("Add to list");
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag != "Player")
			return;

		if(collider.gameObject.GetComponent<Playermovement>().player == "1") {
			if(playersList[0] == true) {
				playersList[0] = false;
				pusherList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "2") {
			if(playersList[1] == true) {
				playersList[1] = false;
				pusherList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "3") {
			if(playersList[2] == true) {
				playersList[2] = false;
				pusherList.Remove(collider.gameObject);
			}
		}
		if(collider.gameObject.GetComponent<Playermovement>().player == "4") {
			if(playersList[3] == true) {
				playersList[3] = false;
				pusherList.Remove(collider.gameObject);
			}
		}
		//Debug.Log ("Remove to list");
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "Hole")
			return;
		isFlying = false;
	}

	void checkWellFlying () {
		if(!isFlying)
			return;
		if(previousPosition == transform.position)
		{
			isFlying = false;
		}
	}

	void checkingSynchro ()
	{
		if(vilainCount == 0) {
			lastSynchro = Time.fixedTime;
			return;
		}
		
		float delta = Time.fixedTime - lastSynchro;
		
		if( delta > deltaSynchro )
		{
			throwPlayer(vilainCount);
			vilainCount = 0;
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
	
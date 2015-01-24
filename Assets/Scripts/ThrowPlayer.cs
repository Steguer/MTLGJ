using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowPlayer : MonoBehaviour {
	private int throwCount;
	private List<GameObject> throwVictimList;
	public float speed = 10f;

	public List<GameObject> ThrowVictimList {
		get {
			return throwVictimList;
		}
	}

	public void IncCount() {
		throwCount++;
		Debug.Log("throwCount: " + throwCount);
	}

	// Use this for initialization
	void Start () {
		throwVictimList = new List<GameObject>();
		throwCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = new Vector3(0, 3.0f, 0);
		if(throwCount >= 1 && (Vector3.Distance(transform.position + tmp, gameObject.transform.position) > 0)) {
			transform.position = Vector3.MoveTowards(transform.position, transform.position + tmp, speed * Time.deltaTime);
		}
		else {
			throwCount = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player") {
			throwVictimList.Add(collider.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		throwVictimList.Remove(collider.gameObject);
	}
}

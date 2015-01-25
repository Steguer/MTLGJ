using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<Playermovement> ().setFalling(true, this.transform.position);
			Debug.Log ("Collider is Enter Hole");
		} else {
			Debug.Log ("Collider is not the Player");
		}
	}
}

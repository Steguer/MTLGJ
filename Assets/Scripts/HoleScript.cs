using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") 
		{
			collider.gameObject.GetComponent<Playermovement> ().setFalling(true, this.transform.position);
			Debug.Log ("Player is Falling");
		} 
		else if( collider.gameObject.tag == "MovableBlock") 
		{
			collider.gameObject.GetComponent<MovableScript> ().setFalling(true, this.transform.position);
			Debug.Log ("Collider is not the Player");
		}
	}
}

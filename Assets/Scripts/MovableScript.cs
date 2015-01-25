using UnityEngine;
using System.Collections;

public class MovableScript : MonoBehaviour {
	bool isFalling = false;
	Vector3 fallingPosition;
	float fallSpeed = 2f;
	float movingTowardsTrapSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling && (transform.localScale.x > 0f))
		{
			Debug.Log("And he falls");
			transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
			transform.position = Vector3.MoveTowards(transform.position, fallingPosition, movingTowardsTrapSpeed * Time.deltaTime);
		}
	}

	public void setFalling(bool value, Vector3 position)
	{
		this.isFalling = value;
		if(value) {
			fallingPosition = position;
		}
	}
}

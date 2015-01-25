using UnityEngine;
using System.Collections;

public class MovableScript : MonoBehaviour {
	protected bool isFalling = false;
	protected Vector3 fallingPosition;
	protected float fallSpeed = 2f;
	protected float movingTowardsTrapSpeed = 1f;
	
	Vector3 origin;
	Vector3 scale;
	
	// Use this for initialization
	void Start () {
		origin = transform.position;
		scale = transform.localScale;
	}
	
	// Update is called once per frame
	public void Update () {
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

	void reset()
	{
		transform.position = origin;
		transform.localScale = scale;
		
	}
}

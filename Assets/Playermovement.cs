using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
	public string player;
    private bool isGrounded = false;


    void Update() {
        //rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
 
        transform.Translate(Input.GetAxis("HorizontalPlayer_" + player) * Time.deltaTime * movementSpeed, 0, 0);
		transform.Translate(0, Input.GetAxis("VerticalPlayer_" + player) * Time.deltaTime * movementSpeed, 0);
		
		if(Input.GetButtonDown("suicidePlayer_" + player)) {
			Debug.Log("suicide of " + player);
		}

		if(Input.GetButtonDown("actionPlayer_" + player)) {
			Debug.Log("action of " + player);
		}

		if(Input.GetButtonDown("pausePlayer_" + player)) {
			Debug.Log("pause of " + player);
		}
	}

    void FixedUpdate()
    {

    }
       

}

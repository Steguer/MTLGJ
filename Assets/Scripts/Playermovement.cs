using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playermovement : MonoBehaviour
{
	public float movementSpeed = 5.0f;
	public string player = "1";
	public bool isFalling = false;
	float fallSpeed = 3f;
	public Vector3 fallingIn;
	float movingTowardsTrapSpeed = 1f;
	protected Animator animator;

	private Vector3 translation;

	void Start ()
	{
		animator = GetComponent<Animator> ();
		animator.SetInteger ("direction", 0);
		animator.speed = 0;
		translation = new Vector3 (0, 0, 0);
	}
	void Update ()
	{
		if (isFalling && (transform.localScale.x > 0f))
		{
			Debug.Log("And he falls");
			transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
			transform.position = Vector3.MoveTowards(transform.position, fallingIn, movingTowardsTrapSpeed * Time.deltaTime);
			return;
		}
		//rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
		translation.Set (0, 0, 0);
		if (Input.GetJoystickNames ().Length >= int.Parse (player)) {
	
			// 3 - Retrieve axis information
			float inputX = Input.GetAxis ("HorizontalPlayer_" + player);
			float inputY = Input.GetAxis ("VerticalPlayer_" + player);

			animator.speed = 1;
			if (inputY > 0) {//haut
					animator.SetInteger ("direction", 1);			
			} else if (inputY < 0) {//bas
					animator.SetInteger ("direction", 2);
			} else if (inputX < 0) {//gauche
					animator.SetInteger ("direction", 3);
			} else if (inputX > 0) {//droite
					animator.SetInteger ("direction", 4);
			} else {
					animator.speed = 0;
			}

			translation.Set (
				Input.GetAxis ("HorizontalPlayer_" + player) * Time.deltaTime * movementSpeed, 
				Input.GetAxis ("VerticalPlayer_" + player) * Time.deltaTime * movementSpeed, 
				0);

			if (Input.GetButtonDown ("suicidePlayer_" + player)) {
					Debug.Log ("suicide of " + player);
			}

			if (Input.GetButtonDown ("actionPlayer_" + player)) {
					Debug.Log ("action of " + player);
			}

			if (Input.GetButtonDown ("pausePlayer_" + player)) {
					Debug.Log ("pause of " + player);
			}
	
		} else {
	
			if (int.Parse (player) == 1) {
				bool isRunning = false;
				animator.speed = 1;

				if (Input.GetKey (KeyCode.W)) {
						animator.SetInteger ("direction", 1);
						isRunning = true;
				}

				if (Input.GetKey (KeyCode.D)) {
						isRunning = true;
						animator.SetInteger ("direction", 4);
				} 

				if (Input.GetKey (KeyCode.S)) {
						isRunning = true;
						animator.SetInteger ("direction", 2);
				}

				if (Input.GetKey (KeyCode.A)) {
						isRunning = true;
						animator.SetInteger ("direction", 3);
				}

				animator.SetBool ("isRunning", isRunning);

				if (isRunning) {
					switch (animator.GetInteger ("direction")) {
					case 1:
						translation.Set (0, 1 * Time.deltaTime * movementSpeed, 0);
						break;
					case 2:
						translation.Set (0, -1 * Time.deltaTime * movementSpeed, 0);
						break;
					case 3:
						translation.Set (-1 * Time.deltaTime * movementSpeed, 0, 0);
						break;		
					case 4:
						translation.Set (1 * Time.deltaTime * movementSpeed, 0, 0);
						break;
					default:
						break;
					}
				}
				if (Input.GetKeyDown (KeyCode.R)) {
					Debug.Log ("suicide of " + player);
				}

				if (Input.GetKeyDown (KeyCode.T)) {
					List<GameObject> test = GetComponent<ThrowPlayer>().ThrowVictimList;
					for(int i=0; i<test.Count; i++) {
						test[i].GetComponent<ThrowPlayer>().IncCount();
					}

					Debug.Log ("action of " + player);
				}

				if (Input.GetKeyDown (KeyCode.Y)) {
					Debug.Log ("pause of " + player);
				}
//Ctrl P2
			} else if (int.Parse (player) == 2) {
				bool isRunning = false;
				animator.speed = 1;
				
				if (Input.GetKey (KeyCode.UpArrow)) {
					animator.SetInteger ("direction", 1);
					isRunning = true;
				}
				
				if (Input.GetKey (KeyCode.RightArrow)) {
					isRunning = true;
					animator.SetInteger ("direction", 4);
				} 
				
				if (Input.GetKey (KeyCode.DownArrow)) {
					isRunning = true;
					animator.SetInteger ("direction", 2);
				}
				
				if (Input.GetKey (KeyCode.LeftArrow)) {
					isRunning = true;
					animator.SetInteger ("direction", 3);
				}
				
				animator.SetBool ("isRunning", isRunning);
				
				if (isRunning) {
					switch (animator.GetInteger ("direction")) {
					case 1:
						translation.Set (0, 1 * Time.deltaTime * movementSpeed, 0);
						break;
					case 2:
						translation.Set (0, -1 * Time.deltaTime * movementSpeed, 0);
						break;
					case 3:
						translation.Set (-1 * Time.deltaTime * movementSpeed, 0, 0);
						break;		
					case 4:
						translation.Set (1 * Time.deltaTime * movementSpeed, 0, 0);
						break;
					default:
						break;
						
					}
				}
				if (Input.GetKeyDown ("[1]")) {
					Debug.Log ("suicide of " + player);
				}
				
				if (Input.GetKeyDown ("[2]")) {
					List<GameObject> test = GetComponent<ThrowPlayer>().ThrowVictimList;
					for(int i=0; i<test.Count; i++) {
						test[i].GetComponent<ThrowPlayer>().IncCount();
					}

					Debug.Log ("action of " + player);
				}
				
				if (Input.GetKeyDown ("[3]")) {
					Debug.Log ("pause of " + player);
				}
			}	
		}
	}
	

	void FixedUpdate ()
	{
		transform.Translate (translation);
	}

	public void setFalling (bool isFalling, Vector3 position)
	{
		bool isFlying = gameObject.GetComponent<ThrowPlayer> ().isFlying;

		if (isFlying)
			return;

		this.isFalling = isFalling;
		this.fallingIn = position;
	}
	
}

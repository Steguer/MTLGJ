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
	private List<GameObject> actionListeners;

		private Vector3 translation;

		void Start ()
		{
				animator = GetComponent<Animator> ();
				animator.SetInteger ("direction", 0);
				animator.speed = 0;
				translation = new Vector3 (0, 0, 0);
				actionListeners = new List<GameObject> ();
		}
		void Update ()
		{
				if (isFalling && (transform.localScale.x > 0f)) {
						Debug.Log ("And he falls");
						transform.localScale -= new Vector3 (fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
						transform.position = Vector3.MoveTowards (transform.position, fallingIn, movingTowardsTrapSpeed * Time.deltaTime);
						return;
				}
				//rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
				translation.Set (0, 0, 0);
				if (int.Parse (player) > 2) {
	
						// 3 - Retrieve axis information
						float inputX = Input.GetAxis ("HorizontalPlayer_" + player);
						float inputY = Input.GetAxis ("VerticalPlayer_" + player);

						bool isRunning = false;
						float delta = 0.5f;

						animator.speed = 1;
						if (inputY > delta) {//haut
								animator.SetInteger ("direction", 1);	
								isRunning = true;
								transform.Translate (0, 1 * Time.deltaTime * movementSpeed, 0);
						} else if (inputY < -delta) {//bas
								animator.SetInteger ("direction", 2);
								isRunning = true;
								transform.Translate (0, -1 * Time.deltaTime * movementSpeed, 0);
						} else if (inputX < -delta) {//gauche
								animator.SetInteger ("direction", 3);
								isRunning = true;
								transform.Translate (-1 * Time.deltaTime * movementSpeed, 0, 0);
						} else if (inputX > delta) {//droite
								animator.SetInteger ("direction", 4);
								isRunning = true;
								transform.Translate (1 * Time.deltaTime * movementSpeed, 0, 0);
						} 

						animator.SetBool ("isRunning", isRunning);

						if(Input.GetButtonDown("ActionPlayer_" + player)){
								this.throwActionA();
						}




						/*if (Input.GetButtonDown ("suicidePlayer_" + player)) {
								Debug.Log ("suicide of " + player);
						}

						if (Input.GetButtonDown ("actionPlayer_" + player)) {
								Debug.Log ("action of " + player);
						}

						if (Input.GetButtonDown ("pausePlayer_" + player)) {
								Debug.Log ("pause of " + player);
						}*/
	
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
									this.throwActionA();
								}

								if (Input.GetKeyDown (KeyCode.Space)) {
									this.throwActionB();
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
									this.throwActionA();
								}

								if (Input.GetKeyDown ("[0]")) {
										this.throwActionB();
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

		public void addActionListener (GameObject listener)
		{
			actionListeners.Add (listener);
		}

		public void removeActionListener (GameObject listener)
		{
			actionListeners.Remove (listener);
		}

		public void throwActionA ()
		{
			List<GameObject> test = GetComponent<ThrowPlayer> ().ThrowVictimList;
			for (int i=0; i<test.Count; i++) {
				test [i].GetComponent<ThrowPlayer> ().IncCount ();
			}
			
			Debug.Log ("Action A of " + player);
		}

		public void throwActionB ()
		{
			foreach (GameObject listener in actionListeners)
			{
				listener.SendMessage("ActionPressed", int.Parse(player ));
			}
			
			Debug.Log ("Action B of " + player);
		}
}
	
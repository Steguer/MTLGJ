/*
 * 
 * P1 : QZDS + A (A) + E (B)
 * P2 : Arrows + RightShift (A) + RightCtrl (B)
 * P3 : Manette ou Pav Num 4865 + "+" (A)+ "Pav Num Enter" (B)
 * P4 : Manette ou 8 (A)
 * */



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playermovement : MonoBehaviour
{
	public float movementSpeed = 5.0f;
	public string player = "1";
	public bool isFalling = true;//false;
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
			GameObject levelManager = GameObject.FindGameObjectWithTag ("LevelManager");
			levelManager.GetComponent<LevelManager>().setPlayer(int.Parse(this.player)-1, this.gameObject);
	}
	void Update ()
	{
		animator.SetBool ("isFalling", isFalling);
		if (isFalling) {
				if ((transform.localScale.x > 0f)) {
						Debug.Log ("And he falls");
						transform.localScale -= new Vector3 (fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
						transform.position = Vector3.MoveTowards (transform.position, fallingIn, movingTowardsTrapSpeed * Time.deltaTime);
						return;
				} else {
						//Reset
						GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ().reset ();
						Debug.Log ("Reset");
						return;
				}
		}

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
				
				if(Input.GetButtonDown("ActionPlayer2_" + player)){
					this.throwActionB();
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
				//return;

		}
		//Reset Général
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			throwReset();
		}
		//Sans manette
		if (int.Parse (player) == 1) {
			bool isRunning = false;
			animator.speed = 1;
			
			if (Input.GetKey (KeyCode.S)) {
				isRunning = true;
				animator.SetInteger ("direction", 2);
				translation.y = -1;
			}
			else if (Input.GetKey (KeyCode.Z)) {
					animator.SetInteger ("direction", 1);
					translation.y = 1;
					isRunning = true;
			}

			if (Input.GetKey (KeyCode.D)) {
					isRunning = true;
					animator.SetInteger ("direction", 4);
					translation.x = 1;
			} else if (Input.GetKey (KeyCode.Q)) {
					isRunning = true;
					animator.SetInteger ("direction", 3);
					translation.x = -1;
			}

			animator.SetBool ("isRunning", isRunning);
			translation.Normalize();
			translation = translation * Time.deltaTime * movementSpeed;

			if (Input.GetKeyDown (KeyCode.A)) {
				throwActionA();
			}

			if (Input.GetKeyDown (KeyCode.E)) {
				throwActionB();
			}
//Ctrl P2
		} else if (int.Parse (player) == 2) {
			bool isRunning = false;
			animator.speed = 1;
			
			if (Input.GetKey (KeyCode.DownArrow)) {
				isRunning = true;
				animator.SetInteger ("direction", 2);
				translation.y = -1;
			}
			else if (Input.GetKey (KeyCode.UpArrow)) {
					animator.SetInteger ("direction", 1);
					translation.y = 1;
					isRunning = true;
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
					isRunning = true;
					animator.SetInteger ("direction", 4);
					translation.x = 1;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
					isRunning = true;
					animator.SetInteger ("direction", 3);
					translation.x = -1;
			}

			animator.SetBool ("isRunning", isRunning);
			translation.Normalize();
			translation = translation * Time.deltaTime * movementSpeed;

			if (Input.GetKeyDown (KeyCode.RightShift)) {
				throwActionA();
			}
			
			if (Input.GetKeyDown (KeyCode.RightControl)) {
				throwActionB();
			}
			
			if (Input.GetKeyDown ("[3]")) {
					Debug.Log ("pause of " + player);
			}
		} else if (int.Parse (player) == 3) {
			bool isRunning = false;
			animator.speed = 1;
			
			if (Input.GetKey ("[5]")) {
				isRunning = true;
				animator.SetInteger ("direction", 2);
				translation.y = -1;
			}
			else if (Input.GetKey ("[8]")) {
					animator.SetInteger ("direction", 1);
					translation.y = 1;
					isRunning = true;
			}

			if (Input.GetKey ("[6]")) {
					isRunning = true;
					animator.SetInteger ("direction", 4);
					translation.x = 1;
			} else if (Input.GetKey ("[4]")) {
					isRunning = true;
					animator.SetInteger ("direction", 3);
					translation.x = -1;
			}

			animator.SetBool ("isRunning", isRunning);
			translation.Normalize();
			translation = translation * Time.deltaTime * movementSpeed;

			if (Input.GetKeyDown ("[7]")) {
				throwActionA();
			}
			
			if (Input.GetKeyDown ("[9]")) {
				throwActionB();
			}
		} else if (int.Parse (player) == 4) {
			bool isRunning = false;
			animator.speed = 1;
			
			if (Input.GetKey (KeyCode.J)) {
				isRunning = true;
				animator.SetInteger ("direction", 2);
				translation.y = -1;
			}
			else if (Input.GetKey (KeyCode.U)) {
				animator.SetInteger ("direction", 1);
				translation.y = 1;
				isRunning = true;
			}
			
			if (Input.GetKey (KeyCode.K)) {
				isRunning = true;
				animator.SetInteger ("direction", 4);
				translation.x = 1;
			} else if (Input.GetKey (KeyCode.H)) {
				isRunning = true;
				animator.SetInteger ("direction", 3);
				translation.x = -1;
			}
			
			animator.SetBool ("isRunning", isRunning);
			translation.Normalize();
			translation = translation * Time.deltaTime * movementSpeed;
			
			if (Input.GetKeyDown (KeyCode.Y)) {
				throwActionA();
			}
			
			if (Input.GetKeyDown (KeyCode.I)) {
				throwActionB();
			}
		}
	}
	
	
	void FixedUpdate ()
		{
            if (!isFalling)
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
			List<GameObject> test = GetComponent<ThrowPlayer> ().PusherList;
			for (int i=0; i<test.Count; i++) {
				test [i].GetComponent<ThrowPlayer> ().IncCount ();
			}
			
			foreach (GameObject listener in actionListeners)
			{
				listener.SendMessage("ActionAPressed", int.Parse(player ));
			}
			
			Debug.Log ("Action A of " + player);
		}

	public void throwActionB ()
		{
			foreach (GameObject listener in actionListeners)
			{
				listener.SendMessage("ActionBPressed", int.Parse(player ));
			}
			
			Debug.Log ("Action B of " + player);

		}
		
		void throwReset ()
		{
			//GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ().reset ();
		}
}
	
/*
 * 
 * P1 : QZDS + A (A) + E (B)
 * P2 : Arrows + RightShift (A) + RightCtrl (B)
 * P3 : Manette ou Pav Num 4865 + "+" (A)+ "Pav Num Enter" (B)
 * P4 : Manette ou 8 (A)
 
 * Reset P1 : BackSpace
 * */



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Playermovement : MonoBehaviour
{
	public float movementSpeed = 5.0f;
	public int playerId = 0;
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
			animator.speed = 1;
			translation = new Vector3 (0, 0, 0);
			actionListeners = new List<GameObject> ();
			GameObject levelManager = GameObject.FindGameObjectWithTag ("LevelManager");
			levelManager.GetComponent<LevelManager>().setPlayer(playerId, this.gameObject);
	}
	void Update ()
	{
		if (isFalling) {
			animator.SetBool ("isFalling", isFalling);
			if ((transform.localScale.x > 0f)) {
				Debug.Log ("And he falls");
				transform.localScale -= new Vector3 (fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
				transform.position = Vector3.MoveTowards (transform.position, fallingIn, movingTowardsTrapSpeed * Time.deltaTime);
			} else {
					//Reset
					GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ().reset ();
			}
			return;
		}
		bool isRunning = false;
		translation.Set (0, 0, 0);
		//Avec une manette
		if (playerId > 1) {
			// 3 - Retrieve axis information
			float inputX = Input.GetAxis ("HorizontalPlayer_" + (playerId+1) );
			float inputY = Input.GetAxis ("VerticalPlayer_" + (playerId+1) );
			float delta = 0.5f;

			if (inputY > delta) {//haut
				animator.SetInteger ("direction", 1);	
				isRunning = true;
				translation.y = 1;
			} else if (inputY < -delta) {//bas
				animator.SetInteger ("direction", 2);
				isRunning = true;
				translation.y = -1;
			} 
			if (inputX < -delta) {//gauche
				animator.SetInteger ("direction", 3);
				isRunning = true;
				translation.x = -1;
			} else if (inputX > delta) {//droite
				animator.SetInteger ("direction", 4);
				isRunning = true;
				translation.x = 1;
			} 
			if(Input.GetButtonDown("ActionPlayer_" + (playerId+1) )){
				this.throwActionA();
			}
			
			if(Input.GetButtonDown("ActionPlayer2_" + (playerId+1) )){
				this.throwActionB();
			}
		}
		//Sans manette
		switch(playerId) {
			case 0 :
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
	
				if (Input.GetKeyDown (KeyCode.A)) {
					throwActionA();
				}
	
				if (Input.GetKeyDown (KeyCode.E)) {
					throwActionB();
				}
				break;
			case 1:
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
				if (Input.GetKeyDown (KeyCode.RightShift)) {
					throwActionA();
				}
				
				if (Input.GetKeyDown (KeyCode.RightControl)) {
					throwActionB();
				}
				
				if (Input.GetKeyDown ("[3]")) {
						Debug.Log ("pause of " + playerId);
				}
				break;
			case 2:
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
				if (Input.GetKeyDown ("[7]")) {
					throwActionA();
				}
				
				if (Input.GetKeyDown ("[9]")) {
					throwActionB();
				}
				break;
			case 3:
			default:
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
				if (Input.GetKeyDown (KeyCode.Y)) {
					throwActionA();
				}
				
				if (Input.GetKeyDown (KeyCode.I)) {
					throwActionB();
				}
			break;
		}
		animator.SetBool ("isRunning", isRunning);
		translation.Normalize();
		translation = translation * Time.deltaTime * movementSpeed;
		
		//Reset Général
		if (playerId == 0 && Input.GetKeyDown (KeyCode.Backspace)) {
			throwReset();
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

	public int addActionListener (GameObject listener)
	{
		if(!actionListeners.Contains(listener) ) {
			actionListeners.Add (listener);
		}
		return playerId;
	}

	public int removeActionListener (GameObject listener)
	{
		actionListeners.Remove (listener);
		return playerId;
	}

    void throwActionA ()
	{		
		foreach (GameObject listener in actionListeners)
		{
			listener.SendMessage("ActionAPressed", playerId);
		}
		
		//Debug.Log ("Action A of " + player);
	}

	void throwActionB ()
	{
		foreach (GameObject listener in actionListeners)
		{
			listener.SendMessage("ActionBPressed", playerId);
		}
		
		//Debug.Log ("Action B of " + player);
	}
	
	void throwReset ()
	{
		GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager> ().reset ();
		Debug.Log ("Reset !");
	}
}
	
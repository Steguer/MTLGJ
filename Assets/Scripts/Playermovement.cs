using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
	public string player;

	protected Animator animator;

	void Start () 
	{
		
		animator = GetComponent<Animator>();
	}

    void Update() {
        
	}

	void OnCollisionEnter(Collision collision) {

		
	}
	
	void setAllFalse(){
		animator.SetBool ("IsUp", false);
		animator.SetBool ("IsDown", false);
		animator.SetBool ("IsLeft", false);
		animator.SetBool ("IsRight", false);
		animator.speed=1;
	}

    void FixedUpdate()
    {
		//rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
		
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("HorizontalPlayer_" + player);
		float inputY = Input.GetAxis("VerticalPlayer_" + player);
		
		setAllFalse ();
		if (inputY > 0) {//haut
			animator.SetBool ("IsUp", true);			
		} else if (inputY < 0) {//bas
			animator.SetBool ("IsDown", true);
		} else if (inputX < 0) {//gauche
			animator.SetBool ("IsLeft", true);
		} else if (inputX > 0) {//droite
			animator.SetBool ("IsRight", true);
		} else {
			animator.speed=0;
		}
		
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
		// 5 - Move the game object
		//rigidbody2D.velocity = movement;
    }
       

}

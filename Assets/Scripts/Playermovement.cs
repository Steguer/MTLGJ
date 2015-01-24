using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
	public float movementSpeed = 5.0f;
	public string player = "1";
    public bool isFalling = false;
    float fallSpeed = 3f;
    public Trap fallingIn;
    float movingTowardsTrapSpeed = 1f;
	
	protected Animator animator;
	
	void Start () 
	{
		
		animator = GetComponent<Animator>();
		animator.SetInteger("direction", 0);
		animator.speed=0;
		
	}
	
	void Update() {

        if (isFalling && (transform.localScale.x > 0f))
        {
            Debug.Log("And he falls");
            transform.localScale -= new Vector3(fallSpeed * Time.deltaTime, fallSpeed * Time.deltaTime, 0f);
            transform.position = Vector3.MoveTowards(transform.position, fallingIn.gameObject.transform.position, movingTowardsTrapSpeed * Time.deltaTime);
            return;
        }

		//rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
		
		if (Input.GetJoystickNames().Length >= int.Parse(player)) {
			
			
			// 3 - Retrieve axis information
			float inputX = Input.GetAxis ("HorizontalPlayer_" + player);
			float inputY = Input.GetAxis ("VerticalPlayer_" + player);
			
			animator.speed=1;
			if (inputY > 0) {//haut
				animator.SetInteger("direction", 1);			
			} else if (inputY < 0) {//bas
				animator.SetInteger("direction", 2);
			} else if (inputX < 0) {//gauche
				animator.SetInteger("direction", 3);
			} else if (inputX > 0) {//droite
				animator.SetInteger("direction", 4);
			} else {
				animator.speed = 0;
			}
			
			transform.Translate (Input.GetAxis ("HorizontalPlayer_" + player) * Time.deltaTime * movementSpeed, 0, 0);
			transform.Translate (0, Input.GetAxis ("VerticalPlayer_" + player) * Time.deltaTime * movementSpeed, 0);
			
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
			
			if(int.Parse(player)==1){
				
				
				if(Input.GetKeyDown (KeyCode.W)){
					animator.SetInteger("direction", 1);
					animator.speed=1;
				}
				else if(animator.GetInteger("direction")==1 && Input.GetKeyUp (KeyCode.W))
				{
					animator.SetInteger("direction", 0);
					animator.speed=0;
				}
				
				if(Input.GetKeyDown (KeyCode.D)){
					animator.SetInteger("direction", 4);
					animator.speed=1;
				}
				else if(animator.GetInteger("direction")==4 && Input.GetKeyUp (KeyCode.D))
				{
					animator.SetInteger("direction", 0);
					animator.speed=0;
				}
				
				if(Input.GetKeyDown (KeyCode.S)){
					animator.SetInteger("direction", 2);
					animator.speed=1;
				}
				else if(animator.GetInteger("direction")==2 && Input.GetKeyUp (KeyCode.S))
				{
					animator.SetInteger("direction", 0);
					animator.speed=0;
				}
				
				if(Input.GetKeyDown (KeyCode.A)){
					animator.SetInteger("direction", 3);
					animator.speed=1;
				}
				else if(animator.GetInteger("direction")==3 && Input.GetKeyUp (KeyCode.A))
				{
					animator.SetInteger("direction", 0);
					animator.speed=0;
				}
				
				
				switch(animator.GetInteger("direction")){
				case 1:
					transform.Translate (0, 1* Time.deltaTime * movementSpeed, 0);
					break;
				case 2:
					transform.Translate (0, -1* Time.deltaTime * movementSpeed, 0);
					break;
				case 3:
					transform.Translate (-1* Time.deltaTime * movementSpeed, 0,0);
					break;		
				case 4:
					transform.Translate (1* Time.deltaTime * movementSpeed, 0,0);
					break;
				default:
					break;
					
				}
				
				if (Input.GetKeyDown(KeyCode.R)) {
					Debug.Log ("suicide of " + player);
				}
				
				if (Input.GetKeyDown (KeyCode.T)) {
					Debug.Log ("action of " + player);
				}
				
				if (Input.GetKeyDown (KeyCode.Y)) {
					Debug.Log ("pause of " + player);
				}
				
				
			}
			
				else if(int.Parse(player)==2){
					
					
					if(Input.GetKeyDown (KeyCode.UpArrow)){
						animator.SetInteger("direction", 1);
						animator.speed=1;
					}
					else if(animator.GetInteger("direction")==1 && Input.GetKeyUp(KeyCode.UpArrow))
					{
						animator.SetInteger("direction", 0);
						animator.speed=0;
					}
					
					if(Input.GetKeyDown (KeyCode.RightArrow)){
						animator.SetInteger("direction", 4);
						animator.speed=1;
					}
					else if(animator.GetInteger("direction")==4 && Input.GetKeyUp (KeyCode.RightArrow))
					{
						animator.SetInteger("direction", 0);
						animator.speed=0;
					}
					
					if(Input.GetKeyDown (KeyCode.DownArrow)){
						animator.SetInteger("direction", 2);
						animator.speed=1;
					}
					else if(animator.GetInteger("direction")==2 && Input.GetKeyUp (KeyCode.DownArrow))
					{
						animator.SetInteger("direction", 0);
						animator.speed=0;
					}
					
					if(Input.GetKeyDown (KeyCode.LeftArrow)){
						animator.SetInteger("direction", 3);
						animator.speed=1;
					}
					else if(animator.GetInteger("direction")==3 && Input.GetKeyUp (KeyCode.LeftArrow))
					{
						animator.SetInteger("direction", 0);
						animator.speed=0;
					}
					
					
					switch(animator.GetInteger("direction")){
					case 1:
						transform.Translate (0, 1* Time.deltaTime * movementSpeed, 0);
						break;
					case 2:
						transform.Translate (0, -1* Time.deltaTime * movementSpeed, 0);
						break;
					case 3:
						transform.Translate (-1* Time.deltaTime * movementSpeed, 0,0);
						break;		
					case 4:
						transform.Translate (1* Time.deltaTime * movementSpeed, 0,0);
						break;
					default:
						break;
						
					}
					
					
					}
			
		}
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
		// 5 - Move the game object
		//rigidbody2D.velocity = movement;
	}
	
}

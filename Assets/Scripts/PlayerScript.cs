using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour {
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	
	// 2 - Store the movement
	private Vector2 movement;

	protected Animator animator;

	void Start () 
	{

		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

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

	}

	void animate(){
		}

	void setAllFalse(){
		animator.SetBool ("IsUp", false);
		animator.SetBool ("IsDown", false);
		animator.SetBool ("IsLeft", false);
		animator.SetBool ("IsRight", false);
		animator.speed=1;
	}
	
	void OnDestroy()
	{
	//	transform.parent.gameObject.AddComponent<GameOverScript> ();
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}

}

using UnityEngine;
using System.Collections;


public class StepCounter : MonoBehaviour
{
	
		public int compteur;
		private int frameCompteur;
		private float playerX;
		private float playerY;
	
		void Start ()
		{
				this.compteur = 0;
				this.frameCompteur = 0;
				this.playerX = transform.position.x;
				this.playerY = transform.position.y;
		}
	
		void Update ()
		{
				float newPlayerX = transform.position.x;
				float newPlayerY = transform.position.y;
				if (newPlayerX != this.playerX || newPlayerY != this.playerY) {
						frameCompteur++;
						this.playerX = newPlayerX;
						this.playerY = newPlayerY;
				}
				if (frameCompteur == 7) {
						compteur++;
						Debug.Log (compteur);
						frameCompteur = 0;
				}
		}
		void OnDestroy ()
		{
				// transform.parent.gameObject.AddComponent<GameOverScript> ();
		}
		void FixedUpdate ()
		{
				// 5 - Move the game object
				//rigidbody2D.velocity = movement;
		}
	
}
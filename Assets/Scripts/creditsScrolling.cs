using UnityEngine;
using System.Collections;

public class creditsScrolling : MonoBehaviour
{
		private float cumulativeTime = 0.0f;
		private float yPosition = Screen.height;
		private bool reroll = false;
		private int vitesse = 40;


		void OnGUI ()
		{
				if (yPosition >= -300 && !reroll) {
						yPosition -= Time.deltaTime * vitesse;
						//at 50 pixels per 2
						//seconds (or 25 pixels per
						//1 second

			GUI.Box (new Rect (0, yPosition, Screen.width, 1000), "The End !\n\nDesigner\n\n François LIM\n\n\nProgrammers\n\n Kevin LEBLANC\n\n Steven GERARD\n\n Jean-Philippe PARENT\n\n Yvan RICHER\n\n  Corentin RAOULT\n\n");
			//GUI.Box (new Rect (0, yPosition+1*60, Screen.width, 1000), "Programmers\n\n	");	
				} else if (yPosition <= Screen.height) {
						reroll = true;
						yPosition += Time.deltaTime * 7 * vitesse;
			GUI.Box (new Rect (0, yPosition, Screen.width, 1000), "Designer\n\n François LIM\n\n\nProgrammers\n\n Kevin LEBLANC\n\n Steven GERARD\n\n Jean-Philippe PARENT\n\n Yvan RICHER\n\n  Corentin RAOULT\n\n");
		} else {


						//loadlevel
			Application.LoadLevel(Application.loadedLevel+1); 

				}
		
				/*if (cumulativeTime > Screen.height) {
			//GUI.Box (new Rect (0, 50, 500, 100),"dfghj"); //Because chances are that cumulativeTime won't
						//end up at exactly 2, it will probably go over
				}*/
		}
}
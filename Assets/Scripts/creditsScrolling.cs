using UnityEngine;
using System.Collections;

public class creditsScrolling : MonoBehaviour
{
		private float cumulativeTime = 0.0f;
		private float yPosition = Screen.height;
		private bool reroll = false;
		private int vitesse = 25;

		void OnGUI ()
		{
				if (yPosition >= -200 && !reroll) {
						yPosition -= Time.deltaTime * vitesse;
						//at 50 pixels per 2
						//seconds (or 25 pixels per
						//1 second
						GUI.Box (new Rect (0, yPosition, Screen.width, 1000), "Programmers\n\n Credits\n\n Credits\n\n Credits\n\n Credits\n\n  Credits\n\n Credits\n\n");
						
				} else if (yPosition <= Screen.height) {
						reroll = true;
						yPosition += Time.deltaTime * 6 * vitesse;
						GUI.Box (new Rect (0, yPosition, Screen.width, 1000), "Credits\n\n Credits\n\n Credits\n\n Credits\n\n Credits\n\n  Credits\n\n Credits\n\n");
				} else {
						//loadlevel
                    Destroy(this);
				}
		
				/*if (cumulativeTime > Screen.height) {
			//GUI.Box (new Rect (0, 50, 500, 100),"dfghj"); //Because chances are that cumulativeTime won't
						//end up at exactly 2, it will probably go over
				}*/
		}
}
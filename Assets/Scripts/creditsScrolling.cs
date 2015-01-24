using UnityEngine;
using System.Collections;

public class creditsScrolling : MonoBehaviour
{
		float cumulativeTime = 0.0f;
		float yPosition = Screen.height;

		void OnGUI ()
		{
				if (yPosition >= -200) {
						yPosition -= Time.deltaTime * 25;
						//at 50 pixels per 2
						//seconds (or 25 pixels per
						//1 second
						GUI.Box (new Rect (0, yPosition, Screen.width, 1000), "Credits\n\n Credits\n\n Credits\n\n Credits\n\n Credits\n\n  Credits\n\n Credits\n\n");
						
				} else {
						//loadlevel
					Debug.Log("loadlevel1");
				}
		
				/*if (cumulativeTime > Screen.height) {
			//GUI.Box (new Rect (0, 50, 500, 100),"dfghj"); //Because chances are that cumulativeTime won't
						//end up at exactly 2, it will probably go over
				}*/
		}
}
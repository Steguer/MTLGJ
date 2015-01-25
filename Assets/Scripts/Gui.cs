using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {
	public float timer = 100;
	
	private GameObject[] playerArray;
	private float timeBuffer;

	// Use this for initialization
	void Start () {
		playerArray = GameObject.FindGameObjectsWithTag("Player");
		timeBuffer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeBuffer >= 1) {
			timer -= Time.time - timeBuffer;
			timeBuffer = Time.time;
		}
	}
	
	void OnGUI() {
		for(int i = 0; i < playerArray.Length; ++i) {
			if(playerArray[i] != null) {
				switch(i) {
				case 0:
					GUILayout.BeginArea (new Rect (0, 0, Screen.width/5, Screen.height/10));
					GUI.color = Color.cyan;
					break;
				case 1:
					GUILayout.BeginArea (new Rect (Screen.width-Screen.width/5, 0, Screen.width/5, Screen.height/10));
					GUI.color = Color.green;
					break;
				case 2:
					GUILayout.BeginArea (new Rect (0, Screen.height-Screen.height/10, Screen.width/5, Screen.height/10));
					GUI.color = Color.yellow;
					break;
				case 3:
					GUILayout.BeginArea (new Rect (Screen.width-Screen.width/5, Screen.height-Screen.height/10, Screen.width/5, Screen.height/10));
					GUI.color = Color.magenta;
					break;
				default:
					GUILayout.BeginArea (new Rect (0,0,Screen.width/5,Screen.height/10));
					break;
				}

				GUILayout.BeginHorizontal();

				GUILayout.Box("Steps: " + playerArray[i].GetComponent<StepCounter>().compteur);
				
				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}
		GUILayout.BeginArea(new Rect(Screen.width/2 - Screen.width/10, Screen.height/100, Screen.width/5, Screen.height/10));
		GUI.color = Color.white;

		if(timer <= 0) {
			GUILayout.Box("Try again");
		}
		else {
			GUILayout.Box(""+(int)timer);
		}
		GUILayout.EndArea();
	}
}

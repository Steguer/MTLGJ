﻿using UnityEngine;
using System.Collections;

public class GameOverScreen	: MonoBehaviour {
	
	public Texture aTexture;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.anyKey) {
			Application.LoadLevel(5);
		}
		
	}
	
	void OnGUI() {
		if (!aTexture) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}
		GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), aTexture, ScaleMode.ScaleToFit, true, 0	);
	}
	
	
}

using UnityEngine;
using System.Collections;

public class LevelManagerStored : MonoBehaviour {
	public static int currentRoom = 0;
	public static int playersNbr = 4;


	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	public int getCurrentRoom (){
				return currentRoom;
		}

	public int setCurrentRoom (int value ){
		currentRoom = value;
		return currentRoom;
	}
}

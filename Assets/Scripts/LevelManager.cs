using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int starterRoom;
	public GameObject[] players;
	public GameObject[] rooms;

	void Start ()
	{
		int currentRoom = GetComponent<LevelManagerStored> ().getCurrentRoom();
		if(currentRoom != null) {
			changeRoom (currentRoom);
			Debug.Log ("Start Current Room Loaded "+currentRoom);
		}
		else {
			Debug.Log("Start No current Room");
		}
	}

	public void changeRoom (int roomValue)
	{
		GameObject room = rooms[roomValue];
		GetComponent<LevelManagerStored> ().setCurrentRoom ( roomValue ); 
		
		GameObject prevCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		prevCamera.camera.active = false;
		GameObject nextCamera = ((RoomManager)room.GetComponent<RoomManager> ()).getCamera ();
		nextCamera.camera.active = true;//.SetActive (true);
		Debug.Log ("camera : " + nextCamera.tag);


		GameObject startCaseObject = room.GetComponent<RoomManager> ().getStarterCase ();
		Vector3 startCase = startCaseObject.transform.position;
		startCase.z = players[1].transform.position.z;
		for (int i = 0; i < players.Length; i++) {
			players [i].transform.position = startCase;
			startCase.x += 0.1f;
		}

		Debug.Log ("changeRoom Room Loaded "+room.tag);
	}

	public void reset ()
	{
		int currentRoom = GetComponent<LevelManagerStored> ().getCurrentRoom();
		Application.LoadLevel (Application.loadedLevel);
		Debug.Log ("Reset LevelManager");
		if(currentRoom != null) {
			changeRoom (currentRoom);
			Debug.Log ("Current Room Loaded "+currentRoom);
		}
		else {
			Debug.Log("No current Room");
		}
	}

	public void setRoom (int id, GameObject room){
		if(id >= rooms.Length) {
			Debug.Log("Id too high");
			return;
		}
		rooms[id] = room;
	}

	public void setPlayer (int id, GameObject player){
		if(id >= players.Length) {
			Debug.Log("Id too high");
			return;
		}
		players[id] = player;
	}
}

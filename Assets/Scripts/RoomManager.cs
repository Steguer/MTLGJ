using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {
	public GameObject starterCase;
	public GameObject camera;
	public int id;

	// Use this for initialization
	void Start () {
		if(starterCase != null) {
			Quaternion rotation = new Quaternion();
			starterCase.transform.rotation = rotation;
		}

		GameObject levelManager = GameObject.FindGameObjectWithTag ("LevelManager");
		levelManager.GetComponent<LevelManager>().setRoom(this.id, this.gameObject);
	}
	
	public GameObject getCamera ()
	{
		return camera;
	}

	public GameObject getStarterCase ()
	{
		return starterCase;
	}
}

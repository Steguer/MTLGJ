using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public bool state = false;
    public SwitchEvent parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider2d) 
    {
        Debug.Log("Entering");
        parent.activateEvent();
    }

    void OnTriggerStay2D(Collider2D collider2d) {

    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        Debug.Log("Exiting");
        parent.deactivateEvent();
    }
}

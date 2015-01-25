using UnityEngine;
using System.Collections;

public class FloorSwitch : Switch {

    public bool state = false;
    public SwitchEvent parent;
    public Sprite sprite1;
    public Sprite sprite2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider2d) 
    {
        Debug.Log("Entering");
        GetComponent<SpriteRenderer>().sprite = sprite2;
        parent.activateEvent();
    }

    void OnTriggerStay2D(Collider2D collider2d) {

    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        Debug.Log("Exiting");
        GetComponent<SpriteRenderer>().sprite = sprite1;
        parent.deactivateEvent();
    }
}

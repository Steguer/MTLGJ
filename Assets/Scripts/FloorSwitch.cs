using UnityEngine;
using System.Collections;

public class FloorSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    Vector3 origin;

	// Use this for initialization
	void Start () {
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider2d) 
    {
        if (collider2d.gameObject.tag != "proximity")
        {
            Debug.Log("Entering");
            GetComponent<SpriteRenderer>().sprite = sprite2;
            parent.activateEvent();
        }
    }

    void OnTriggerStay2D(Collider2D collider2d) {

    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.tag != "proximity")
        {
            Debug.Log("Exiting");
            GetComponent<SpriteRenderer>().sprite = sprite1;
            parent.deactivateEvent();
        }
    }

    void reset()
    {
        transform.position = origin;
        GetComponent<SpriteRenderer>().sprite = sprite1;
        parent.deactivateEvent();
    }
}

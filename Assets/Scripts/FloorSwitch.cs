using UnityEngine;
using System.Collections;

public class FloorSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    bool isActive = false;

    void OnTriggerEnter2D(Collider2D collider2d) 
    {
        if (collider2d.gameObject.tag != "Proximity")
        {
            toggle(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.tag != "Proximity")
        {
            toggle (false);
        }
    }

	void toggle (bool activate) 
	{
		if(isActive == activate)
			return;
		
		if(activate) {
			Debug.Log("activating FloorSwitch");
			GetComponent<SpriteRenderer>().sprite = sprite2;
			parent.activateEvent();
		}
		else {
			Debug.Log("Desactive FloorSwitch");
			GetComponent<SpriteRenderer>().sprite = sprite1;
			parent.deactivateEvent();
		}
		isActive = activate;
	}
}

using UnityEngine;
using System.Collections;

public class FloorSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    bool isActive = false;
    int nbrObject = 0;

    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Proximity"
        	|| coll.gameObject.tag == "Wall"
        	|| coll.gameObject.tag == "Floor")
        	return;
        if(coll.gameObject.tag != "Player"
        	&& coll.gameObject.tag != "MovableBlock")
        	return;
        
        Debug.Log("FloorTriggerEnter's tag : "+coll.tag);
        	
	    toggle(true);
	    nbrObject++;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Proximity")
        {
            nbrObject--;
            if(nbrObject == 0)
            	toggle (false);
        }
    }

	void toggle (bool activate) 
	{
		if(isActive == activate)
			return;
		
		if(parent == null) {
			Debug.Log ("Error : FloorSwitch's parent not Set !");
			return;
		}
		
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

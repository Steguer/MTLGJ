using UnityEngine;
using System.Collections;

public class WallSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool isLocked = false; // if locked, the switch cannot be activated, even if in range
    private bool isActive = false;
    
	public void ActionAPressed (int player)
    {
		if (!this.isLocked) {
			
			this.isActive = !this.isActive; // toggle the switch
			
			if(parent == null) {
				Debug.Log ("Error : WallSwitch not Set !");
				return;
			}
			
			if (this.isActive) {
				parent.activateEvent();
				GetComponent<SpriteRenderer>().sprite = sprite2;
			}
			else {
				parent.deactivateEvent();
				GetComponent<SpriteRenderer>().sprite = sprite1;
			}
		}
	}     
}

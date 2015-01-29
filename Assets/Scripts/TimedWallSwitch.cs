using UnityEngine;
using System.Collections;

public class TimedWallSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool isLocked = false; // if locked, the switch cannot be activated, even if in range
    private bool isActivatable = false; // if a player is in collision with the switch, it becomes "activatable"
    private bool isActive = false;
    public float activeMaxTime = 30f;
    public float activeTime = 0f;
    public float decrementStep = 1f;


    // Update is called once per frame
    void Update() {
        if (activeTime > 0f) {
            this.activeTime -= decrementStep;
            if (this.activeTime <= 0f) {
                this.activeTime = 0f;

                this.isActive = false;
                parent.deactivateEvent();
                GetComponent<SpriteRenderer>().sprite = sprite1;
            }
        }

    }
       
	public void ActionAPressed (int player)
	{
		if (!this.isLocked) {
			
			this.isActive = !this.isActive; // toggle the switch
			
			if(parent == null) {
				Debug.Log ("Error : TimedWallSwitch not Set !");
				return;
			}
			
			if (this.isActive) {
				parent.activateEvent();
				this.activeTime = this.activeMaxTime;
				GetComponent<SpriteRenderer>().sprite = sprite2;
			}
			else {
				parent.deactivateEvent();
				GetComponent<SpriteRenderer>().sprite = sprite1;
			}
		}
	}   
}

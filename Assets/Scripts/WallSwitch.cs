using UnityEngine;
using System.Collections;

public class WallSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool isLocked = false; // if locked, the switch cannot be activated, even if in range
    private bool isActivatable = false; // if a player is in collision with the switch, it becomes "activatable"
    private bool isActive = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
        

    }
  

    
    void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag != "Player")
			return;
			  
        if (!this.isLocked) {
            this.isActivatable = true;
        }
        
		coll.gameObject.GetComponent<Playermovement> ().addActionListener (this.gameObject);
    }

    void OnTriggerStay2D(Collider2D coll) {
		if(coll.tag != "Player")
			return;
			
		coll.gameObject.GetComponent<Playermovement> ().addActionListener (this.gameObject);
        
    }

   
    void OnTriggerExit2D(Collider2D coll) {
		if(coll.tag != "Player")
			return;
		
		if (!this.isLocked) {
			this.isActivatable = false;
		}
		
		coll.gameObject.GetComponent<Playermovement> ().removeActionListener (this.gameObject);
    }
    
    public void ActionAPressed (int player)
    {
		if (this.isActivatable) {
			
			this.isActive = !this.isActive; // toggle the switch
			
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
	
	public void ActionBPressed (int player)
	{
	}
     
}

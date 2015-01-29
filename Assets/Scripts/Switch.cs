using UnityEngine;
using System.Collections;

public abstract class Switch : MonoBehaviour {

    protected SwitchEventManager parent;
    
    public void setParent(SwitchEventManager p)
    {
    	parent = p;
    }
	
	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag != "Player")
			return;
		
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
		
		coll.gameObject.GetComponent<Playermovement> ().removeActionListener (this.gameObject);
	}
	
	public void ActionAPressed () 
	{}
	
	public void ActionBPressed ()
	{}
}

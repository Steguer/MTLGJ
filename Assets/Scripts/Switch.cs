using UnityEngine;
using System.Collections;

public abstract class Switch : MonoBehaviour {

    protected SwitchEvent parent;
    
    public void setParent(SwitchEvent p)
    {
    	parent = p;
    }

}

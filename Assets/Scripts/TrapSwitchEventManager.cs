using UnityEngine;
using System.Collections;

public class TrapSwitchEventManager : SwitchEventManager {

    public GameObject[] trapSwitches;
    public GameObject[] traps;
    public bool allSwitchesAreNeeded = false;
    bool allSwitchesActivated = false;
    int activatedSwitchCount = 0;

    void Start()
    {
        foreach (GameObject element in trapSwitches)
        {
			if(element != null)
            	element.GetComponent<Switch>().setParent(this);
        }
    }

    public override void activateEvent()
    {
        activatedSwitchCount += 1;
        if (activatedSwitchCount == trapSwitches.GetLength(0)) //Shit-induced hack
            allSwitchesActivated = true;
        Debug.Log(trapSwitches.GetLength(0) + " activateEvent");
        if ((activatedSwitchCount > 0) && (!allSwitchesAreNeeded || allSwitchesActivated))
        {
            Debug.Log("Turning on traps");
            foreach (GameObject element in traps) {
            	if(element != null)
                	element.GetComponent<Trap>().toggle();
        	}
        }
    }

    public override void deactivateEvent()
    {
        allSwitchesActivated = false;
        activatedSwitchCount -= 1;
        if ((!allSwitchesAreNeeded) || (allSwitchesAreNeeded && (activatedSwitchCount == trapSwitches.GetLength(0) - 1)))
        {
			foreach (GameObject element in traps) {
				if(element != null)
					element.GetComponent<Trap>().toggle();
			}
        }
    }

}

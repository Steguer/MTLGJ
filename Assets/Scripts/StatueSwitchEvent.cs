using UnityEngine;
using System.Collections;

public class StatueSwitchEvent : SwitchEvent
{

    public GameObject[] switches;
    public GameObject statue;
    public bool allSwitchesAreNeeded = true;
    bool allSwitchesActivated = false;
    int activatedSwitchCount = 0;

    void Start()
    {
        foreach (GameObject element in switches)
        {
            element.GetComponent<Switche>().parent = this;
        }
    }

    public override void activateEvent()
    {
        activatedSwitchCount += 1;
        if (activatedSwitchCount == switches.GetLength(0))
            allSwitchesActivated = true;
        if ((activatedSwitchCount > 0) && (!allSwitchesAreNeeded || allSwitchesActivated))
        {
            statue.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public override void deactivateEvent()
    {
        
    }

}

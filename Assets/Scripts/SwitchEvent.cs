using UnityEngine;
using System.Collections;

public class SwitchEvent : MonoBehaviour {

    public GameObject[] switches;
    public GameObject[] traps;
    public bool allSwitchesAreNeeded = false;
    bool allSwitchesActivated = false;
    int activatedSwitchCount = 0;

    void Start()
    {
        foreach (GameObject element in switches)
        {
            element.GetComponent<Switch>().parent = this;
        }
    }

    public void activateEvent()
    {
        activatedSwitchCount += 1;
        if (activatedSwitchCount == switches.GetLength(0)) //Shit-induced hack
            allSwitchesActivated = true;
        Debug.Log(switches.GetLength(0) + "RRRR");
        if ((activatedSwitchCount > 0) && (!allSwitchesAreNeeded || allSwitchesActivated))
        {
            Debug.Log("Turning on traps");
            foreach (GameObject element in traps)
                element.GetComponent<Trap>().turnOn();
        }
    }

    public void deactivateEvent()
    {
        allSwitchesActivated = false;
        activatedSwitchCount -= 1;
        if ((activatedSwitchCount == 0 && !allSwitchesAreNeeded) || (allSwitchesAreNeeded && (activatedSwitchCount < switches.GetLength(0)))) //Shit-induced hack x 2
        {
            Debug.Log("Turning off traps");
            foreach (GameObject element in traps)
                element.GetComponent<Trap>().turnOff();
        }
    }

}

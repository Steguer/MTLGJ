using UnityEngine;
using System.Collections;

public class SwitchEvent : MonoBehaviour {

    public GameObject[] trapSwitches;
    public GameObject[] traps;
    public bool allSwitchesAreNeeded = false;
    bool allSwitchesActivated = false;
    int activatedSwitchCount = 0;

    void Start()
    {
        foreach (GameObject element in trapSwitches)
        {
            element.GetComponent<TrapSwitch>().parent = this;
        }
    }

    public void activateEvent()
    {
        activatedSwitchCount += 1;
        if (activatedSwitchCount == trapSwitches.GetLength(0)) //Shit-induced hack
            allSwitchesActivated = true;
        Debug.Log(trapSwitches.GetLength(0) + "RRRR");
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
        if ((activatedSwitchCount == 0 && !allSwitchesAreNeeded) || (allSwitchesAreNeeded && (activatedSwitchCount < trapSwitches.GetLength(0)))) //Shit-induced hack x 2
        {
            Debug.Log("Turning off traps");
            foreach (GameObject element in traps)
                element.GetComponent<Trap>().turnOff();
        }
    }

}

using UnityEngine;
using System.Collections;

public class TimedSwitchEvent : SwitchEvent {

    public float simultaneousMaxActivationWindow = 30f;
    public float simultaneousActivationWindow = 0;
    public float decrementStep = 1f;

    public GameObject[] switches;
    public GameObject[] traps;
    public bool allSwitchesAreNeeded = false;
    bool allSwitchesActivated = false;
    int activatedSwitchCount = 0;
    public bool stayActivated = true;

    void Start() {
        foreach (GameObject element in switches) {
            element.GetComponent<Switch>().parent = this;
        }
    }



    // Update is called once per frame
    void Update() {
        if (simultaneousActivationWindow > 0f) {
            this.simultaneousActivationWindow -= decrementStep;
            if (this.simultaneousActivationWindow < 0f) {
                this.simultaneousActivationWindow = 0f;

            }
        }

    }


    public override void activateEvent() {
        // reset the activation window when you activate the first switch
        if (activatedSwitchCount == 0) {
            simultaneousActivationWindow = simultaneousMaxActivationWindow;
            Debug.Log("first ");
        }

        activatedSwitchCount += 1;


        if (activatedSwitchCount == switches.GetLength(0)) {
            allSwitchesActivated = true;
            Debug.Log("all");
        }

        if ((activatedSwitchCount > 0) && (!allSwitchesAreNeeded || allSwitchesActivated) && simultaneousActivationWindow > 0f) {
            
            foreach (GameObject element in traps)
                element.GetComponent<Trap>().turnOn();
        }
    }

    public override void deactivateEvent() {

        if (!this.stayActivated) {

            allSwitchesActivated = false;
            activatedSwitchCount -= 1;
            if ((activatedSwitchCount == 0 && !allSwitchesAreNeeded) || (allSwitchesAreNeeded && (activatedSwitchCount < switches.GetLength(0)))) //Shit-induced hack x 2
            {
                //Debug.Log("Turning off traps");
                foreach (GameObject element in traps)
                    element.GetComponent<Trap>().turnOff();
            }
        }
    }
}

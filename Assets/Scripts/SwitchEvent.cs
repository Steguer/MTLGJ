using UnityEngine;
using System.Collections;

public abstract class SwitchEvent : MonoBehaviour {
    public abstract void activateEvent(); 

    public abstract void deactivateEvent();
}

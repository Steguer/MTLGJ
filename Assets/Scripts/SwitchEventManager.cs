using UnityEngine;
using System.Collections;

public abstract class SwitchEventManager : MonoBehaviour {

    public abstract void activateEvent(); 

    public abstract void deactivateEvent();
}

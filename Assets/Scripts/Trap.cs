using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    public bool isOn = false;

    public void turnOn() 
    {
        Debug.Log("Turning trap on");
        GetComponent<SpriteRenderer>().sprite = sprite2;
        isOn = true;
    }

    public void turnOff()
    {
        Debug.Log("Turning trap off");
        GetComponent<SpriteRenderer>().sprite = sprite1;
        isOn = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isOn)
        {
            collider.gameObject.GetComponent<Playermovement>().isFalling = true;
           // collider.gameObject.GetComponent<Animator>().active = false;
            collider.gameObject.GetComponent<Playermovement>().fallingIn = this.transform.position;
        }
    }
}

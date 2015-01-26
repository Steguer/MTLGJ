using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;
    private bool isOn = false;
	public bool startOpen = false;

	void Start ()
	{
		if(startOpen == true) {
			isOn = true;
			GetComponent<SpriteRenderer>().sprite = sprite2;
		}
	}

    public void toggle()
    {
        if (isOn)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1;
            isOn = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
            isOn = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (isOn)
        {
            if (collider.gameObject.tag == "Player")
            {
                collider.gameObject.GetComponent<Playermovement>().setFalling(true, this.transform.position);
                Debug.Log("Player is Falling");
            }
			else if (collider.gameObject.tag == "MovableBlock")
            {
                collider.gameObject.GetComponent<MovableScript>().setFalling(true, this.transform.position);
                Debug.Log("Collider is not the Player");
            }
        }
    }

    void reset()
    {
        isOn = false;
        GetComponent<SpriteRenderer>().sprite = sprite1;
    }
}

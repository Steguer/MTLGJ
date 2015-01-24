using UnityEngine;
using System.Collections;

public class PickupStatue : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<SpriteRenderer>().active = false;
        Application.LoadLevelAdditive(1); 
    }
}

using UnityEngine;
using System.Collections;

public class PickupStatue : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Roll credits");
        GetComponent<SpriteRenderer>().active = false;
    }
}

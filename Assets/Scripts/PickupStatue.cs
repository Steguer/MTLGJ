using UnityEngine;
using System.Collections;

public class PickupStatue : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<SpriteRenderer>().active = false;
        Time.timeScale = 0;
        Application.LoadLevelAdditive(1); 
    }
}

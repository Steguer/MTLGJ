using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider2d) {
        Debug.Log("entered swtich");
    }

    void OnTriggerStay2D(Collider2D collider2d) {
        Debug.Log("on switch");
    }

    void OnTriggerExit2D(Collider2D collider2d) {
        Debug.Log("exit switch");
    }
}

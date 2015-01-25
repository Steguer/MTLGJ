using UnityEngine;
using System.Collections;

public class PickupStatue : MonoBehaviour {

	public AudioClip snd;
	private bool played;

	void Start(){
		played = false;
	}

	void/*IEnumerator*/ OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<SpriteRenderer>().active = false;

		if(played == false){
			//audio.PlayOneShot(snd);
			//yield return new WaitForSeconds(snd.length);
			//played = true;
			Application.LoadLevel(Application.loadedLevel+1);
		}
       
    }

	void OnTriggerExit(Collider col){
		played = false;
	}
}



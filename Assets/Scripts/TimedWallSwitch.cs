using UnityEngine;
using System.Collections;

public class TimedWallSwitch : Switch {

    public bool state = false;
    public Sprite sprite1;
    public Sprite sprite2;
    public bool isLocked = false; // if locked, the switch cannot be activated, even if in range
    private bool isActivatable = false; // if a player is in collision with the switch, it becomes "activatable"
    private bool isActive = false;
    public float activeMaxTime = 300f;
    public float activeTime = 0f;
    public float decrementStep = 1f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (activeTime > 0f) {

            Debug.Log(this.activeTime);

            this.activeTime -= decrementStep;
            if (this.activeTime <= 0f) {
                this.activeTime = 0f;

                Debug.Log(this.activeTime);
                this.isActive = false;
                parent.deactivateEvent();
                GetComponent<SpriteRenderer>().sprite = sprite1;
            }
        }

    }



    void OnTriggerEnter2D(Collider2D collider2d) {

        if (!this.isLocked) {
            this.isActivatable = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider2d) {

        if (this.isActivatable) {
            if (collider2d.tag == "Player") {

                //Input.GetKeyDown( collider2d.gameObject.GetComponent<Playermovement>().player. ) // FIXME: use specific player `action` button

                if (Input.GetKeyDown(KeyCode.Return)) {

                    this.isActive = !this.isActive; // toggle the switch

                    if (this.isActive) {
                        parent.activateEvent();
                        // reset the activation time
                        this.activeTime = this.activeMaxTime;
                        
                        GetComponent<SpriteRenderer>().sprite = sprite2;
                    }
                    else {
                        parent.deactivateEvent();
                        GetComponent<SpriteRenderer>().sprite = sprite1;
                    }
                }
            }
        }
    }


    void OnTriggerExit2D(Collider2D collider2d) {

        if (!this.isLocked) {
            this.isActivatable = false;
        }
    }
}

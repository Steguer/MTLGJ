using UnityEngine;
using System.Collections;

public class CamTrigerer : MonoBehaviour {

    public GameObject camera;

    /* 0 = top
     * 1 = right
     * 2 = down
     * 3 = left
     */
    public int position = 0;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (position == 0)
        {
            camera.GetComponent<MoveCam>().moveUp();
            this.position = 2;
        }
        else if (position == 1)
        {
            camera.GetComponent<MoveCam>().moveRight();
            this.position = 3;
        }
        else if (position == 2)
        {
            camera.GetComponent<MoveCam>().moveDown();
            this.position = 0;
        }
        else if (position == 3)
        {
            camera.GetComponent<MoveCam>().moveLeft();
            this.position = 1;
        }
        else
            Debug.Log("Invalid cam trigger 'position' variable");
    }
}

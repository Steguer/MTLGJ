using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

    public Vector3 targetPosition = new Vector3(0f, 0f, -10f);
    public bool isMoving = false;
    public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
        if ((Vector3.Distance(targetPosition, gameObject.transform.position) > 0) && (isMoving))
            transform.position = Vector3.MoveTowards(transform.position, targetPosition , speed * Time.deltaTime);
        else
            isMoving = false;
	}

    public void moveUp()
    {
        isMoving = true;
        targetPosition.y += 10f;
    }

    public void moveRight()
    {
        isMoving = true;
        targetPosition.x += 17f;
    }

    public void moveDown()
    {
        isMoving = true;
        targetPosition.y -= 10f;
    }

    public void moveLeft()
    {
        isMoving = true;
        targetPosition.x -= 17f;
    }
}

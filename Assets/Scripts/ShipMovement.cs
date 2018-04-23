using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    // 1 for normal, -1 for inverted
    public int verticalInvert = 1;
    public int horizontalInvert = 1;

    public float xMoveLimit = 5f;
    public float yMoveLimit = 5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal =  Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        Vector3 direction = new Vector3(horizontalInvert * horizontal, verticalInvert * vertical, 0f);
        Vector3 finalDirection = new Vector3(horizontalInvert * horizontal, verticalInvert * vertical, 1f);
        
        if ((transform.localPosition + (direction * movementSpeed * Time.deltaTime)).x > xMoveLimit || (transform.localPosition + (direction * movementSpeed * Time.deltaTime)).x < -xMoveLimit)
        {
            direction = new Vector3(0f, direction.y, direction.z);
            finalDirection = new Vector3(0f, finalDirection.y, finalDirection.z);
        }
        
        if ((transform.localPosition + (direction * movementSpeed * Time.deltaTime)).y > yMoveLimit || (transform.localPosition + (direction * movementSpeed * Time.deltaTime)).y < -yMoveLimit)
        {
            direction = new Vector3(direction.x, 0f, direction.z);
            finalDirection = new Vector3(finalDirection.x, 0f, finalDirection.z);
        }
        
        transform.position += direction * movementSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection + transform.parent.forward), Mathf.Deg2Rad * 50.0f);
        
	}

    public void Ascend()
    {
        //bool pastTopLimit = 
    }

    public void Descend()
    {

    }

    public void BankLeft()
    {

    }

    public void BankRight()
    {

    }
}

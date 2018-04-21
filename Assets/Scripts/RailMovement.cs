using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;

    // Use this for initialization
    void Start ()
	{
        waypoints[0].LookAt(transform.position);
        for (int x = 1; x < waypoints.Count; x++)
        {
            waypoints[x].LookAt(waypoints[x - 1].transform.position);
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, other.position, Time.deltaTime * speed);

        if (waypoints.Count != 0)
        {
            float step = speed * Time.fixedDeltaTime;
            Vector3 moveVector = Vector3.Normalize(transform.position - waypoints[0].transform.position);
            transform.position = transform.position - moveVector * step;

            Quaternion originalRotation = transform.rotation;
            Vector3 targetDirection = waypoints[0].position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.fixedDeltaTime * .2f, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }        
    }

    public Vector3 GetMovementVector()
    {
        Vector3 moveVector = Vector3.zero;
        if (waypoints.Count != 0)
            moveVector = Vector3.Normalize(transform.position - waypoints[0].transform.position);
        return moveVector;
    }

    public void NextWaypoint(bool loops)
    {
        if (loops)
        {
            waypoints.Add(waypoints[0]);
        }
        waypoints.RemoveAt(0);
    }
}

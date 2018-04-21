using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	void OnTriggerEnter (Collider col)
	{
        if (col.tag != "PlayerRailGuide")
        {
            return;
        }

        RailMovement railGuide = col.GetComponent<RailMovement>();
        railGuide.NextWaypoint(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy navigational logic

    //Assign a path to the enemy

    [SerializeField] EnemyPath path;

    // Remember where to go
    int currentTargetWaypoint = 0;

    // Has the enemy reached the end of their road?
    bool hasReachedEnd = false;

    private void Update()
    {
        if(hasReachedEnd == false)
        {
            // move towards target waypoint 
            transform.position = Vector3.MoveTowards(transform.position,
                path.GetWaypoint(currentTargetWaypoint).position,
                5.0f * Time.deltaTime);

            // Close enough?
            if (Vector3.Distance(transform.position,
                path.GetWaypoint(currentTargetWaypoint).position) < 0.2f)

            {
                //Increment target waypoint
                currentTargetWaypoint = currentTargetWaypoint + 1;

                // Did we arrive at the last waypoint?
                if (currentTargetWaypoint >= path.GetTotalNumberOfWaypoints())
                {
                    hasReachedEnd = true;
                }
            }
        }      
        
    }

    public void SetPath(EnemyPath incomingPath)
    {
        path = incomingPath;
    }

}

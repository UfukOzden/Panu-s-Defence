using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Stores path data


    //Create a list that stores the waypoints
    [SerializeField] List<Transform> waypoints;

    private void Awake()
    {
        // Initialise the list
        waypoints = new List<Transform>(); 

        // Populate the list with waypoints
        foreach (Transform waypoint in transform)
        {
            waypoints.Add(waypoint);
        }

       
        


    }

    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }


    public int GetTotalNumberOfWaypoints()
    { 
        return waypoints.Count; 
    }

}

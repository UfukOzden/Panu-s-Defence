using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EventManager eventManager;
    [SerializeField] GameSettingsSO gameSettings;

    //Enemy navigational logic

    [SerializeField] float speed = 5f;

    //Health
    [SerializeField] float maxHealth = 20f;
    float currentHealth;
    [SerializeField] HealthBar healthBar;

    // Where the tower should aim 
    [SerializeField] Transform hitTarget;



    //Assign a path to the enemy

    [SerializeField] EnemyPath path;

    // Remember where to go
    int currentTargetWaypoint = 0;

    // Has the enemy reached the end of their road?
    bool hasReachedEnd = false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {

        if (gameSettings.currentGameState == GameStates.inGame)
        {



            if (hasReachedEnd == false)
            {

                //look into the direction of the next waypoint
                transform.LookAt(path.GetWaypoint(currentTargetWaypoint));


                // move towards target waypoint 
                transform.position = Vector3.MoveTowards(transform.position,
                    path.GetWaypoint(currentTargetWaypoint).position,
                    speed * Time.deltaTime);

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
    }

    public void InflictDamage(float incomingDamage) 
    {
        currentHealth -= incomingDamage;

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if(currentHealth <= 0) 
        
        {
            eventManager.MakeMoney(50);
            Destroy(this.gameObject);
        }

    }


    public void SetPath(EnemyPath incomingPath)
    {
        path = incomingPath;
    }

    public Transform GetHitTarget()
    {
        return hitTarget;
    }
}

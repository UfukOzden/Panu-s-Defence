using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Settings
    [SerializeField] float range = 5.0f;
    [SerializeField] Projectile projectile; //What to shoot
    [SerializeField] Transform firingPoint; // Where to shoot from

    private bool towerIsActive;

    // Timers
    [SerializeField] private float firingTimer;
    [SerializeField] private float firingDelay = 1f;

    private float scanningTimer;
    private float scanningDelay = 0.1f;

    //Enemy bookkeeping
    [SerializeField] Enemy targetedEnemy;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Collider[] detectedColliders;
    [SerializeField] List<Enemy> enemiesInRange;

    private void Awake()
    {
       enemiesInRange = new List<Enemy>();// Initialise the list
        towerIsActive = false;
    }

    private void Update()
    {   if (towerIsActive)

        {
            scanningTimer += Time.deltaTime;
            if (scanningTimer >= scanningDelay)
            {
                ScanForEnemies(); //call the scanning method
                scanningTimer = 0f; //reset the scanning timer

            }



            //Charge up the tower
            if (firingTimer < firingDelay)
            {
                firingTimer += Time.deltaTime;
            }

            //Only fire if the tower's charged
            //Only if there's something to shoot at
            if (firingTimer >= firingDelay && targetedEnemy != null)
            {
                Fire();  //Call the fire method
                firingTimer = 0f; //Reset the timer
            }


        }
        
       
    }

    private void ScanForEnemies() 
    {
        // Detect nearby colliders that are on the enemy layer

        detectedColliders = Physics.OverlapSphere(transform.position, range, enemyLayer);

        // Clear the list
        enemiesInRange.Clear();

        foreach (Collider collider in detectedColliders)
        {
            enemiesInRange.Add(collider.GetComponent<Enemy>());
        }

        // Are there any enemies in range?
        // If there is, target one
        if (enemiesInRange.Count != 0)
        {
            targetedEnemy = enemiesInRange[0];
        }

        // If targeted enemy is out of range allow the tower to forget about it

        if (targetedEnemy != null &&
            Vector3.Distance(transform.position, targetedEnemy.transform.position) > range)
        {
            targetedEnemy = null; //Forget about the enemy
        }

    }

    private void Fire()
    {
        if(targetedEnemy == null)
        {
            return; // then stop here
        }

        //Get enemy direction
        Vector3 enemyDirection = (targetedEnemy.GetHitTarget().position - firingPoint.position).normalized;

        // What, where, rotation, tell the projectile where to go
        Instantiate(projectile, firingPoint.position, Quaternion.identity).Setup(enemyDirection, targetedEnemy);
          
    }

    //Visualise the tower's range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    public void ActivateTower() 
    {
        towerIsActive = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Settings
    [SerializeField] float range = 5.0f;
    [SerializeField] Projectile projectile; //What to shoot
    [SerializeField] Transform firingPoint; // Where to shoot from

    //Enemy bookkeeping
    [SerializeField] Enemy targetedEnemy;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Collider[] detectedColliders;
    [SerializeField] List<Enemy> enemiesInRange;

    private void Awake()
    {
       enemiesInRange = new List<Enemy>();// Initialise the list
    }

    private void Update()
    {
        ScanForEnemies(); //call the scanning method
        Fire();            //call the fire method
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
        Instantiate(projectile, firingPoint.position, Quaternion.identity).Setup(enemyDirection);
          
    }

    //Visualise the tower's range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }




}

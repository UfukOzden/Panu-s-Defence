using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Settings
    [SerializeField] float projectileSpeed = 5.0f;
    [SerializeField] float damage = 10f;
    private Enemy targetedEnemy;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Setup(Vector3 enemyDirection, Enemy incomingTargetedEnemy)
    {
        //What's the projectile targeting at? 
        targetedEnemy = incomingTargetedEnemy;

        //Start flying towards the target
        Vector3 force = enemyDirection * projectileSpeed; 
        rb.AddForce(force, ForceMode.Impulse);



    }


    private void OnTriggerEnter(Collider other)
    {
       if (other != null) 
        
        { 
            if(other.gameObject == targetedEnemy.gameObject) 
            {
                targetedEnemy.InflictDamage(damage);
            }

        }
        
        Destroy(this.gameObject);
    }


}

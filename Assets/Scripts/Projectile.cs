using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Settings
    [SerializeField] float projectileSpeed = 5.0f;
    [SerializeField] float damage = 10f;

    [SerializeField] ParticleSystem particleFX;




    private Enemy targetedEnemy;
    private bool isActive;
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
        Vector3 force = enemyDirection * projectileSpeed + new Vector3(0, 1f, 0); 
        rb.AddForce(force, ForceMode.Impulse);



    }

    private void Update()
    {

        if (isActive)
        {

            if (targetedEnemy != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetedEnemy.transform.position, 20f * Time.deltaTime);
            }
        }
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
        
       Instantiate(particleFX, transform.position, Quaternion.identity);


        Destroy(this.gameObject);
    }


}

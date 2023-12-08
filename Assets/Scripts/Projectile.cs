using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettings;
    
    
    //Settings
    [SerializeField] float projectileSpeed = 5.0f;
    [SerializeField] float damage = 10f;

    [SerializeField] ParticleSystem particleFX;




    private Enemy targetedEnemy;
    private bool isActive;
    private Rigidbody rb;

    private Vector3 prevVelocity = Vector3.zero;
    bool projectileIsPaused;

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

        if (gameSettings.currentGameState == GameStates.inGame && !projectileIsPaused)

        {

            if (isActive)
            {

                if (targetedEnemy != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetedEnemy.transform.position, 20f * Time.deltaTime);
                }
            }
            prevVelocity = rb.velocity;
        }
        
        
        
        else if(gameSettings.currentGameState == GameStates.paused && !projectileIsPaused) 
        {
            rb.isKinematic = true;
            projectileIsPaused = true;
        }



        else if (gameSettings.currentGameState == GameStates.inGame && projectileIsPaused) 
        {
            rb.isKinematic = false;
            rb.velocity = prevVelocity;
            projectileIsPaused = false;
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

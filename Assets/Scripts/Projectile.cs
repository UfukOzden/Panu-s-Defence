using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5.0f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Setup(Vector3 enemyDirection)
    {
        //Start flying towards the target
        Vector3 force = enemyDirection * projectileSpeed; 
        rb.AddForce(force, ForceMode.Impulse);



    }


    private void OnTriggerEnter(Collider other)
    {
       
        
        Destroy(this.gameObject);
    }


}

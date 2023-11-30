using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    [SerializeField] EventManager EventManager;

    [SerializeField] LayerMask enemyLayer;


    private void OnTriggerEnter(Collider other)
    {

        if ((enemyLayer.value & (1 << other.transform.gameObject.layer)) > 0) 
      {

            Debug.Log("You're Taking Damage!");

            EventManager.ReduceLives();

            Destroy(other.gameObject);




      }


    }

}


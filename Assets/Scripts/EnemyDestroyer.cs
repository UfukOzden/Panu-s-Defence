using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    
        private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Touched Me");    
        
        Destroy(other.gameObject);
    }


}

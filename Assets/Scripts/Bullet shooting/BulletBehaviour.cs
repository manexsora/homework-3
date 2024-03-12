using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThrownObject"))
        {
            print(other.gameObject.name);
            Destroy(other.gameObject); // Destroy the collided object
            Destroy(gameObject);
            GlobalFunctions.GlobalAddScore(10);
        }
        
    }

}

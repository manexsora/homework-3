using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            Destroy(gameObject); // Destroy the collided object
            
    }

}

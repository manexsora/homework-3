using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay = 5f; // Delay in seconds before destruction

    void Start()
    {
        // Call the Destroy method with a delay
        Destroy(gameObject, delay);
    }
}
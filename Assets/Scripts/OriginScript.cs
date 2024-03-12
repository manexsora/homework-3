using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginScript : MonoBehaviour
{
    public Vector3 pos;
    void Start()
    {
        transform.position = pos;
    }

}

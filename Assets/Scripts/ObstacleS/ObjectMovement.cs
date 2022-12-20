using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.back * SpeedController.speed());
    }
}

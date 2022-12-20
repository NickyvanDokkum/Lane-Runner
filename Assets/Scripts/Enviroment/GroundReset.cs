using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundReset : MonoBehaviour
{
    
    void FixedUpdate()
    {
        if(transform.position.z <= -15) {
            transform.Translate(transform.forward * 50);
        }
    }
}

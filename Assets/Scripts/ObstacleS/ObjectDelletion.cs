using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelletion : MonoBehaviour
{
    void FixedUpdate() {
        if (transform.position.z <= -15) {
            Destroy(gameObject);
        }
    }
}

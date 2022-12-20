using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSidewaysMovement : MonoBehaviour {
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    [SerializeField] private float movement;
    private int movingRight;

    private void Start() {
        bool selection = Random.value >= 0.5f;
        if (selection) {
            movingRight = 1;
        }
        else {
            movingRight = -1;
        }
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.right * movement * movingRight);
        if(transform.position.x <= maxLeft) { movingRight = 1; }
        if (transform.position.x >= maxRight) { movingRight = -1; }
    }
}

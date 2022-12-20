using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int position { get; private set; } = 0;
    [SerializeField] private float moveDistance = 2.5f;
    [SerializeField] private float jumpStrength = 3;
    [SerializeField] private new Rigidbody rigidbody;
    private bool canJump = true;

    void Update() {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground") {
            canJump = true;
        }
    }

    public void Jump() {
        if (canJump) {
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Force);
            canJump = false;
        }
    }

    public void MoveLeft() {
        if(position != -1) {
            position--;
            transform.Translate(Vector3.left * moveDistance);
        }
    }

    public void MoveRight() {
        if (position != 1) {
            position++;
            transform.Translate(Vector3.right * moveDistance);
        }
    }
}

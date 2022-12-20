using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Coilision : MonoBehaviour
{
    public int health { get; private set; }
    [SerializeField] private Text healthText;

    private void Start() {
        health = 3;
        UpdateHealthText();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Obstacle") {
            health--;
            SpeedController.ResetSpeed();
            if (health <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            UpdateHealthText();

            other.enabled = false;
        }
        if(other.tag == "Collectible") {
            PointCounter.HitCollectible();

            Destroy(other.gameObject);
        }
    }

    private void UpdateHealthText() {
        if (healthText != null) {
            healthText.text = "Health: " + health;
        }
    }
}

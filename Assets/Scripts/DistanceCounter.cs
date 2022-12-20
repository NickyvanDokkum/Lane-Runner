using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour {
    [SerializeField] private Text distanceText;
    public static float distance { get; private set; }

    private void Start() {
        distance = 0;
    }

    private void FixedUpdate() {
        distance += SpeedController.speed();

        if (distanceText != null) {
            distanceText.text = "Distance: " + Mathf.Round(distance);
        }
    }
}

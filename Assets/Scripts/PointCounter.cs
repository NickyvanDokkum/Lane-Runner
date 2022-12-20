using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text recordText;
    public static float score { get; private set; } = 0;
    public static int collectibleScore { get; private set; } = 200;
    public static int record { get; private set; } = 0;

    private void Start() {
        if(score > record) {
            record = Mathf.RoundToInt(score);
        }
        if (recordText != null) {
            recordText.text = "Record: " + record;
        }
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score += SpeedController.speed();

        if (scoreText != null) {
            scoreText.text = "Score: " + Mathf.Round(score);
        }
    }

    public static void HitCollectible() {
        score += collectibleScore;
    }
}

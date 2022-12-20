using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private static bool _gameOver = false;

    public static float speed() {
        return _speed;
    }

    private static float _speed;

    void Start()
    {
        ResetSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_gameOver) {
            _speed += Time.fixedDeltaTime * 0.01f;
        }
    }

    public static void ResetSpeed() {
        _speed = 0.05f;
    }

    public static void GameOver() {
        _speed = 0;
        _gameOver = true;
    }
}

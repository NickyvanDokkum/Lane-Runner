using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestObjects {
    GameObject controller;
    ObstacleSpawner obstacleSpawner;
    GameObject[] obstacles;

    [UnityTest]
    public IEnumerator aTestSetup() { //Loads everything at the start to avoid unnecessary loading. This can all also be added to the tests if you really wanted to x.x
        SceneManager.LoadScene("Assets/Tests/TestScenes/TestObjects.Unity");
        yield return null;
        Assert.IsTrue(SceneManager.GetActiveScene().name == "TestObjects");
        Debug.Log("Scene Successfully loaded");


        controller = GameObject.Find("Controller");
        yield return null;
        Assert.IsNotNull(controller);
        Debug.Log("Controller found");

        obstacleSpawner = controller.GetComponent<ObstacleSpawner>();
        yield return null;
        Assert.IsNotNull(obstacleSpawner);
        Debug.Log("ObstacleSpawner script found");

        obstacles = new GameObject[obstacleSpawner.obstacles.Length];
        Debug.Log("Created obstacles array based on size from existing obstacle list");
        yield return null;
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CheckSpawningAllObstacles() {
        for (int i = 0; i < obstacleSpawner.obstacles.Length; i++) {
            Debug.Log("Spawning " + obstacleSpawner.obstacles[i].name);
            obstacles[i] = GameObject.Instantiate(obstacleSpawner.obstacles[i], controller.transform);
            Assert.IsNotNull(obstacles[i]);
            Debug.Log(obstacles[i].name + "successfully spawned");
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator SeeIfObstaclesDelete() {
        yield return new WaitForFixedUpdate();

        for (int i = 0; i < obstacles.Length; i++) {
            Assert.IsNotNull(obstacles[i]);
            Debug.Log(obstacles[i].name + " isn't instantly deleted");
        }
        yield return new WaitForSeconds(5);

        for (int i = 0; i < obstacles.Length; i++) {
            Debug.Log(obstacles[i]);
            Assert.IsTrue(obstacles[i] == null);
            Debug.Log("obstacle " + i + " has succesfully deleted itself");
        }

        yield return null;
    }
}

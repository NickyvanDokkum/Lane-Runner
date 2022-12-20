using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestCollision
{
    Coilision player;

    [UnityTest]
    public IEnumerator aTestSetup()
    {
        SceneManager.LoadScene("Assets/Tests/TestScenes/TestCollision.Unity");
        yield return null;
        Assert.IsTrue(SceneManager.GetActiveScene().name == "TestCollision");
        Debug.Log("Scene Successfully loaded");

        player = GameObject.Find("Player").GetComponent<Coilision>();
        yield return null;
        Assert.IsNotNull(player);
        Debug.Log("Player Coilision script succesfully found");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckCollectibles() {
        Assert.AreEqual(PointCounter.score, DistanceCounter.distance);
        Debug.Log("Starting score correct");

        GameObject collectible = GameObject.Instantiate(Resources.Load("Prefabs/Obstacles/StaticCollectible") as GameObject);
        Assert.NotNull(collectible);
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        Assert.IsTrue(collectible == null);
        Assert.AreEqual((int)PointCounter.score, (int)DistanceCounter.distance + PointCounter.collectibleScore);
        Debug.Log("Score succesfully added");

        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckDamage() {
        Assert.AreEqual(player.health, 3);
        Debug.Log("Starting health correct");

        GameObject obstacle = GameObject.Instantiate(Resources.Load("Prefabs/Obstacles/StaticObstacle") as GameObject);
        Assert.NotNull(obstacle);
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        Assert.IsFalse(obstacle.GetComponent<Collider>().enabled);
        Debug.Log("Collider of obstacle correctly turned off");
        Assert.AreEqual(player.health, 2);
        Debug.Log("Health correctly edited");

        obstacle = GameObject.Instantiate(Resources.Load("Prefabs/Obstacles/StaticObstacle") as GameObject);
        Assert.NotNull(obstacle);
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        Assert.IsFalse(obstacle.GetComponent<Collider>().enabled);
        Debug.Log("Collider of obstacle correctly turned off");
        Assert.AreEqual(player.health, 1);
        Debug.Log("Health correctly edited");

        obstacle = GameObject.Instantiate(Resources.Load("Prefabs/Obstacles/StaticObstacle") as GameObject);
        Assert.NotNull(obstacle);
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        yield return null;
        Assert.IsTrue(player == null);

        player = GameObject.Find("Player").GetComponent<Coilision>();

        Assert.AreEqual(player.health, 3);
        Debug.Log("Game succesfully reloaded after all lives lost");
        yield return null;
    }
}

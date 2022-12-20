using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class TestFullLevel
{
    
    [SetUp]
    public void Setup() {
        SceneManager.LoadScene("Assets/Scenes/MainScene.unity");
    }

    [UnityTest]
    public IEnumerator TestFullLevelWithEnumeratorPasses()
    {
        Assert.IsTrue(SceneManager.GetActiveScene().name == "MainScene");

        Coilision player = GameObject.Find("Player").GetComponent<Coilision>();
        int collectibles = 0;
        int health = 3;

        Assert.AreEqual(player.health, health);
        Assert.AreEqual(PointCounter.score, DistanceCounter.distance);

        yield return new WaitForSeconds(8);
        collectibles++;
        Assert.AreEqual((int)PointCounter.score, (int)DistanceCounter.distance + (PointCounter.collectibleScore * collectibles));
        Debug.Log("Succesfull Collectible " + collectibles);

        yield return new WaitForSeconds(8);
        collectibles++;
        Assert.AreEqual((int)PointCounter.score, (int)DistanceCounter.distance + (PointCounter.collectibleScore * collectibles));
        Debug.Log("Succesfull Collectible " + collectibles);

        yield return new WaitForSeconds(2);
        collectibles++;
        Assert.AreEqual((int)PointCounter.score, (int)DistanceCounter.distance + (PointCounter.collectibleScore * collectibles));
        Debug.Log("Succesfull Collectible " + collectibles);

        yield return new WaitForSeconds(2);
        collectibles++;
        Assert.AreEqual((int)PointCounter.score, (int)DistanceCounter.distance + (PointCounter.collectibleScore * collectibles));
        Debug.Log("Succesfull Collectible " + collectibles);

        yield return new WaitForSeconds(3);
        health--;
        Assert.AreEqual(player.health, health);
        Debug.Log(health + " remaining");

        yield return new WaitForSeconds(19);
        health--;
        Assert.AreEqual(player.health, health);
        Debug.Log(health + " remaining");

        yield return new WaitForSeconds(3);

        Assert.NotZero(PointCounter.record);
        Debug.Log("Reset succesful");

        yield return null;
    }
}

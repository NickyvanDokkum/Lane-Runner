using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


public class TestPlayerMovement {

    private Movement player;

    //Setup does not do what was required as it does it every time a new test in the script starts and does not allow for waits
    /*[SetUp]
    public void SetupTest() {
        Debug.Log("Setup");
    }

    private void GetPlayer() {
        Debug.Log("Getting Player GameObject");
        player = GameObject.Find("Player");
    }*/

    [UnityTest] //Loads everything at the start to avoid unnecessary loading. This can all also be added to each test if you really wanted to
    public IEnumerator aTestSetup() {
        SceneManager.LoadScene("Assets/Tests/TestScenes/TestPlayerMovement.Unity");
        yield return null;
        Assert.IsTrue(SceneManager.GetActiveScene().name == "TestPlayerMovement");
        Debug.Log("Scene Successfully loaded");
        player = GameObject.Find("Player").GetComponent<Movement>();
        Assert.IsNotNull(player);
        Debug.Log("Player successfullly found");
    }


    [UnityTest]
    public IEnumerator TestPlayerMovementLeft() {
        float xPos = player.transform.position.x;
        player.MoveLeft();
        Debug.Log("Moving Left Once");
        Assert.Less(player.transform.position.x, xPos);
        Debug.Log("Position Changed Correctly");
        if (player.position != -1) {
            player.MoveLeft();
            Debug.Log("Correction");
        }
        xPos = player.transform.position.x;
        player.MoveLeft();
        Debug.Log("Shouldn't move again");
        Assert.AreEqual(xPos, player.transform.position.x);
        Debug.Log("Succesful boundry");
        yield return null;
    }


    [UnityTest]
    public IEnumerator TestPlayerMovementRight() {

        float xPos = player.transform.position.x;
        player.MoveRight();
        Debug.Log("Moving Left Once");
        Assert.Greater(player.transform.position.x, xPos);
        Debug.Log("Position Changed Correctly");
        if (player.position != 1) {
            player.MoveRight();
            Debug.Log("Correction");
        }
        xPos = player.transform.position.x;
        player.MoveRight();
        Debug.Log("Shouldn't move again");
        Assert.AreEqual(xPos, player.transform.position.x);
        Debug.Log("Succesful boundry");
        yield return null;
    }


    [UnityTest]
    public IEnumerator TestPlayerMovementJump() {
        yield return new WaitForFixedUpdate();
        Assert.AreEqual(player.transform.position.y, 0.5f);
        Debug.Log("Checked start Y position");

        player.Jump();

        yield return new WaitForFixedUpdate();

        Assert.Greater(player.transform.position.y, 0.5f);
        Debug.Log("Player movement is higher than start");

        yield return new WaitForSeconds(1f);

        Assert.Greater(player.transform.position.y, 0.5f);
        Debug.Log("after 1 second still jumping");

        yield return new WaitForSeconds(1f);
        Debug.Log(player.transform.position.y);
        Assert.IsTrue(player.transform.position.y == 0.5f);
        Debug.Log("Jump ended after 2 seconds");
        yield return null;
    }
}

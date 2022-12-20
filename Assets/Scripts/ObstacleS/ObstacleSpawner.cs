using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] private Transform objectsContainer;
    [SerializeField] private float laneWidth = 2.5f;
    private List<GameObject> currentObstacles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(69);

        if(obstacles.Length == 0) {
            Debug.LogError("No obstacles added");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentObstacles.Count > 0) {
            if(currentObstacles[0] == null) {
                currentObstacles.RemoveAt(0);
            }
        }

        if(currentObstacles.Count == 0 || currentObstacles[currentObstacles.Count-1].transform.position.z <= 20) {
            int obstacle = Random.Range(0, obstacles.Length);
            int lane = (int)Mathf.Floor(Random.value * 3 - 1);
            currentObstacles.Add(Instantiate(obstacles[obstacle], new Vector3(laneWidth*lane, obstacles[obstacle].transform.position.y, 30), Quaternion.identity, objectsContainer));
        }
    }
}

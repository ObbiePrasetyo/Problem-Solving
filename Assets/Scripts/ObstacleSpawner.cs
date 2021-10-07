using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private float maxYPosition = -3.8f;
    private float maxXPosition = -8;

    private void Start()
    {
        InvokeRepeating ("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        float xPosition = Random.Range(-maxXPosition, maxYPosition);
        float yPosition = Random.Range(-maxYPosition, maxXPosition);

        GameObject obstacle = Instantiate(obstaclePrefabs);
        obstacle.transform.position = new Vector3 (xPosition, yPosition, 1);
    }
}

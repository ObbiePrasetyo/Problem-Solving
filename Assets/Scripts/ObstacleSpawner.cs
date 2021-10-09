using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    private float maxYPosition = -3.8f;
    private float maxXPosition = 8;

    private List <GameObject> obstacle = new List <GameObject>();
    private GameObject obstacleToSpawn;

    private void Start()
    {
        InvokeRepeating ("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < obstacle.Count; i++)
        {
            if (obstacle[i].activeSelf == false)
            {
                obstacle[i].SetActive(true);
                obstacle[i].transform.position = PositioningObstacle();
                obstacleToSpawn = obstacle[i];
                return;
            }
        }

        if (obstacleToSpawn == null)
        {
            obstacleToSpawn = Instantiate(obstaclePrefabs);
            obstacleToSpawn.transform.position = PositioningObstacle();
            obstacle.Add(obstacleToSpawn);

        }

        obstacleToSpawn = null;
    }

    Vector3 RandomizePosition()
    {
        float xPosition = Random.Range(-maxXPosition, maxXPosition);
        float yPosition = Random.Range(-maxYPosition, maxYPosition);

        return new Vector3(xPosition, yPosition, 0);
    }

    Vector3 PositioningObstacle()
    {
        Vector3 objectPosition = RandomizePosition();

        Vector3 playerPosition = FindObjectOfType<PlayerMovement>().gameObject.transform.position;
        while (Vector3.Distance(playerPosition, objectPosition) < 2)
            objectPosition = RandomizePosition();

        return objectPosition;
    }
}

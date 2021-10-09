using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerProblem8 : MonoBehaviour
{
    public GameObject obstaclePrefabs;

    private float maxYPosition = 3.8f;
    private float maxXPosition = 7;

    private List<GameObject> obstacles = new List<GameObject>();
    private GameObject obstacleToSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 1, 2);
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                obstacles[i].SetActive(true);
                obstacles[i].transform.position = PositioningObstacle();
                obstacleToSpawn = obstacles[i];
                return;
            }
        }

        if (obstacleToSpawn == null)
        {
            obstacleToSpawn = Instantiate(obstaclePrefabs);
            obstacleToSpawn.transform.position = PositioningObstacle();
            obstacles.Add(obstacleToSpawn);

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

        Vector3 playerPosition = FindObjectOfType<BallController>().gameObject.transform.position;
        while (Vector3.Distance(playerPosition, objectPosition) < 2)
            objectPosition = RandomizePosition();

        return objectPosition;
    }
}

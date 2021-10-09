using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 1f;

    private float maxYPosition = 3.8f;
    private float maxXPosition = 7;

    private List<GameObject> obstacles = new List<GameObject>();
    private GameObject obstacleToSpawn;

    public void StartObstacle()
    {
        InvokeRepeating("SpawnObstacle", 2, spawnRate);
    }

    void SpawnObstacle()
    {
        bool isFilled = RandomBoolean();

        for (int i = 0; i < obstacles.Count; i++)
        {
            if (isFilled)
            {
                
                if (obstacles[i].activeSelf == false && obstacles[i].gameObject.tag == "Obstacle2")
                {
                    obstacleToSpawn = obstacles[i];
                    obstacleToSpawn.SetActive(true);
                    obstacleToSpawn.transform.position = PositioningObstacle();
                    return;
                }
                
            }
            else
            {
                
                if (obstacles[i].activeSelf == false && obstacles[i].gameObject.tag == "Obstacle1")
                {
                    obstacleToSpawn = obstacles[i];
                    obstacleToSpawn.SetActive(true);
                    obstacleToSpawn.transform.position = PositioningObstacle();
                    return;
                }
            }
        }

        if (obstacleToSpawn == null)
        {
            obstacleToSpawn = Instantiate(obstaclePrefabs[isFilled? 0 : 1]);
            obstacles.Add(obstacleToSpawn);
            obstacleToSpawn.transform.position = PositioningObstacle();
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
        Vector3 stickPosition = FindObjectOfType<PlayerController>().gameObject.transform.position;
        while (Vector3.Distance(playerPosition, objectPosition) < 1 || Vector3.Distance(stickPosition, objectPosition) < 2) 
            objectPosition = RandomizePosition();

        return objectPosition;
    }

    bool RandomBoolean()
    {
        if (Random.value >= 0.5)
            return true;
        return false;
    }
}

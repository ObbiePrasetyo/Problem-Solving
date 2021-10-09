using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPosition;

    private List<GameObject> balls;

    public void StartBall()
    {
        InvokeRepeating("spawnBall", 30, 60);
    }

    void spawnBall()
    {
        GameObject spawnedBall = Instantiate(ball);
        spawnedBall.transform.position = spawnPosition.position;
    }

    void DeactivateBall(GameObject ball) 
    {
        ball.SetActive(false);
    }
}

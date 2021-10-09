using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            FindObjectOfType<ObstaclesSpawner>().StartObstacle();
            FindObjectOfType<BallSpawner>().StartBall();
            FindObjectOfType<UIManager>().StartHints();
            this.gameObject.SetActive(false);
        }
    }
}

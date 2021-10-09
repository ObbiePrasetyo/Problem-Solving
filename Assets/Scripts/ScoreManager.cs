using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region singleton

    private static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<ScoreManager>();
            return _instance;
        }
    }

    #endregion

    private static int score;
    public Text scoreText;

    public static int Score
    {
        get
        {
            return score;
        }
    }

    private void Awake()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score : " + score;
    }

    public void IncrementScore()
    {
        score++;
    }


}
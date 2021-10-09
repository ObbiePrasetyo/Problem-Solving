using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    

    public Text ScoreText;
    public Text timeText;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject gameOverPanel;
    public GameObject hintButton;
    public GameObject gamePausePanel;
    public Sprite[] hintButtonSprites; 


    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }
    public bool isHintsOn;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        float second = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60);
        float minute = Mathf.FloorToInt(Time.timeSinceLevelLoad / 60);

        timeText.text = minute + " : " + second;
    }

    public void TogglePauseGame()
    {
        IsPaused = !IsPaused;
        gamePausePanel.SetActive(IsPaused);
        Time.timeScale = IsPaused ? 0 : 1;
    }

    public void GameOver()
    {
        ScoreText.text = ScoreManager.Score.ToString();
        IsGameOver = true;
        StopAllCoroutines();
        gameOverPanel.SetActive(true);

        Time.timeScale = IsGameOver ? 0 : 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    /*public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }*/

    public void StartHints()
    {
        isHintsOn = true;
        StartCoroutine(Hints(StartHints));
    }

    IEnumerator Hints(System.Action onCompleted)
    {
        yield return new WaitForSeconds(1f);
        hint1.SetActive(true);

        yield return new WaitForSeconds(8f);
        hint1.SetActive(false);

        hint2.SetActive(true);

        yield return new WaitForSeconds(8f);
        hint2.SetActive(false);

        hint3.SetActive(true);

        yield return new WaitForSeconds(8f);
        hint3.SetActive(false);

        onCompleted?.Invoke();
    }

    public void StopHints()
    {
        isHintsOn = false;
        StopAllCoroutines();
        hint1.SetActive(false);
        hint2.SetActive(false);
        hint3.SetActive(false);
    }

    public void ToggleHints()
    {
        Invoke(isHintsOn ? "StopHints" : "StartHints", 0.1f);
        Image buttonSprite = hintButton.GetComponent<Image>();
        buttonSprite.sprite = isHintsOn ? hintButtonSprites[0] : hintButtonSprites[1];
    }
}

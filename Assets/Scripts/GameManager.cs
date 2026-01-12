using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public GameObject titleScreen;

    public TextMeshProUGUI finalScoreText;
    public Button restartButton;
    public GameObject gameOverText;
    public GameObject score;
    public bool isGameActive = false;
    private int finalScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.SetActive(false);
        finalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        isGameActive = true;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        titleScreen.SetActive(false);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        score.SetActive(false);
        finalScore = scoreManager.GetTotalScore();
        finalScoreText.text = "Final Score: " + finalScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

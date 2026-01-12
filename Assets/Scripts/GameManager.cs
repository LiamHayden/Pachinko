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

    // Highscore variables
    private int highscore = -1;
    private int highscore2 = -1;
    private int highscore3 = -1;

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
        SaveGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load the Scoreboard scene
    public void Scoreboard()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveGame()
    {
        int hs1 = PlayerPrefs.GetInt("Highscore", 0);
        int hs2 = PlayerPrefs.GetInt("Highscore2", 0);
        int hs3 = PlayerPrefs.GetInt("Highscore3", 0);

        if (finalScore > hs1)
        {
            // Shift down
            PlayerPrefs.SetInt("Highscore3", hs2);
            PlayerPrefs.SetInt("Highscore2", hs1);
            PlayerPrefs.SetInt("Highscore", finalScore);
        }
        else if (finalScore > hs2)
        {
            PlayerPrefs.SetInt("Highscore3", hs2);
            PlayerPrefs.SetInt("Highscore2", finalScore);
        }
        else if (finalScore > hs3)
        {
            PlayerPrefs.SetInt("Highscore3", finalScore);
        }

        PlayerPrefs.Save();
    }
}

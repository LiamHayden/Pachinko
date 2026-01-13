using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    private ScoreManager scoreManager;

    public GameObject titleScreen;

    public TextMeshProUGUI finalScoreText;
    public TMP_InputField playerNameInputField;
    public Button restartButton;
    public GameObject gameOverText;
    public GameObject score;
    public bool isGameActive = false;
    private int finalScore;

    // Highscore variables
    private int highscore = -1;
    private int highscore2 = -1;
    private int highscore3 = -1;
    private string playerName;
    private string playerName2;
    private string playerName3;

    public string PlayerName { get; private set; }

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
        if (finalScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            // Save 2nd place to 3rd place
            highscore3 = PlayerPrefs.GetInt("Highscore2", 0);
            playerName3 = PlayerPrefs.GetString("PlayerName2", "No Name");
            PlayerPrefs.SetInt("Highscore3", highscore3);
            PlayerPrefs.SetString("PlayerName3", playerName3);

            // Save 1st place to 2nd place
            highscore2 = PlayerPrefs.GetInt("Highscore", 0);
            playerName2 = PlayerPrefs.GetString("PlayerName", "No Name");
            PlayerPrefs.SetInt("Highscore2", highscore2);
            PlayerPrefs.SetString("PlayerName2", playerName2);

            // Save new 1st place
            highscore = finalScore;
            playerName = playerNameInputField.text;

            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.SetString("PlayerName", playerName);
        }
        else if (finalScore > PlayerPrefs.GetInt("Highscore2", 0))
        {
            // move current second place to 3rd place
            highscore3 = PlayerPrefs.GetInt("Highscore2", 0);
            playerName3 = PlayerPrefs.GetString("PlayerName2", "No Name");
            PlayerPrefs.SetInt("Highscore3", highscore3);
            PlayerPrefs.SetString("PlayerName3", playerName3);

            // save new 2nd place
            highscore2 = finalScore;
            playerName2 = playerNameInputField.text;

            PlayerPrefs.SetInt("Highscore2", highscore2);
            PlayerPrefs.SetString("PlayerName2", playerName2);
        }
        else if (finalScore > PlayerPrefs.GetInt("Highscore3", 0))
        {
            // save new 3rd place
            highscore3 = finalScore;
            playerName3 = playerNameInputField.text;

            PlayerPrefs.SetInt("Highscore3", highscore3);
            PlayerPrefs.SetString("PlayerName3", playerName3);
        }

        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

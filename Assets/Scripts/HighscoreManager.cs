using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI firstPlace;
    public TextMeshProUGUI secondPlace;
    public TextMeshProUGUI thirdPlace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPlace.text = 
            "Rank 1: " + PlayerPrefs.GetInt("Highscore", 0) + " --- " + PlayerPrefs.GetString("PlayerName", "No name");
        secondPlace.text = 
            "Rank 2: " + PlayerPrefs.GetInt("Highscore2", 0) + " --- " + PlayerPrefs.GetString("PlayerName2", "No name");
        thirdPlace.text = 
            "Rank 3: " + PlayerPrefs.GetInt("Highscore3", 0) + " --- " + PlayerPrefs.GetString("PlayerName3", "No name");
    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}

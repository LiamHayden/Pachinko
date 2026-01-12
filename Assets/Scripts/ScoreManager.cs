using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject counterCanvas;

    public Text counterText;
    private int totalScore = 0;
    
    private void Update()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        DisplayCounter();
    }
    public void AddScore(int score)
    {
        totalScore  += score;
        counterText.text = "Score: " + totalScore;
    }

    private void DisplayCounter()
    {
        if (gameManager.isGameActive)
        {
            counterCanvas.SetActive(true);
        }
    }

    public int GetTotalScore()
    {
        return totalScore; 
    }
}

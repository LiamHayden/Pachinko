using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        gameManager.StartGame();
    }
}

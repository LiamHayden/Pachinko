using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(-1.19000006f, 36.3220482f, 0);

    public GameObject spherePrefab;
    private GameObject currentSphere;
    private PlayerController playerController;
    private GameManager gameManager;
    private Rigidbody currentRb;

    public int maxSpawnCount;
    public int spawnCount = 0;
    public bool isAlive = false;
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        gameManager = FindAnyObjectByType<GameManager>();
        SpawnNewSphere();
        ReleaseSphere();
    }

    // Spawn new sphere if the first sphere is released
    private void SpawnNewSphere()
    {
        if(!isAlive && gameManager.isGameActive == true)
        {
            currentSphere = Instantiate(spherePrefab, spawnPos, spherePrefab.transform.rotation);
            currentRb = currentSphere.GetComponent<Rigidbody>();
            currentRb.useGravity = false;
            isAlive = true;
        } else if (spawnCount >= maxSpawnCount && !isGameOver)
        {
            isGameOver = true;
            gameManager.GameOver();
        }
            

     }

    // Release sphere when the player presses space
    private void ReleaseSphere()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentRb.useGravity = true;
            playerController.SetIsReleased(true);
        }
    }

    public void SetIsAlive(bool newIsAlive)
    {
        isAlive = newIsAlive;
    }

    public void IncreaseSpawnCounter()
    {
        spawnCount ++;
    }
}

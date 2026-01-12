using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private ScoreManager scoreManager;

    public SpawnManager spawnManager;
    public Text CounterText;
    public int Score;


    private void Start()
    {
        spawnManager = FindAnyObjectByType<SpawnManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.AddScore(Score);
        spawnManager.SetIsAlive(false);
        spawnManager.IncreaseSpawnCounter();
    }

}

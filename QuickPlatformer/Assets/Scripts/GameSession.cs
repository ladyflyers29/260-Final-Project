﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    public int playerLives = 3;
    public int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;


    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }


    public void ProcessPlayerDeath()
    {
        if (playerLives >= 1)
        {
            TakeLife();
            livesText.text = playerLives.ToString();
        }
        else
        {
           // ResetGameSession();
        }
    }

    public void ResetGameSession()
    {
       // SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}

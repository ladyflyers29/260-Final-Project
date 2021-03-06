﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerState : MonoBehaviour {

    bool isAlive = true;
    GameObject deathScene;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        isAlive = true;
        deathScene = GameObject.FindGameObjectWithTag("Death");
        deathScene.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<GameSession>().playerLives  == 0f)
        {
            isAlive = false;
            showDeathScreen();
        }
    }
        
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    void showDeathScreen()
    {
        Time.timeScale = 0;
        deathScene.SetActive(true);
   //   FindObjectOfType<GameSession>().ResetGameSession();
    }
}

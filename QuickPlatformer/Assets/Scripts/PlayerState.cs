using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    bool isAlive = true;
    GameObject deathScene;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        showDeathScreen();
	}

    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            isAlive = false;
        }
    }

    void showDeathScreen()
    {
        if (!isAlive)
        {
            Time.timescale = 0;
            
        }
    }
}

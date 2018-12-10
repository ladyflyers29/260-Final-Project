using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {

    [SerializeField] int coinAmount = 10;

    private void OnTriggerEnter2D (Collider2D col)
    {
        AddPoints(coinAmount);
        Destroy(gameObject);
    }

    private void AddPoints(int pointsToAdd)
    {
        FindObjectOfType<GameSession>().AddToScore(pointsToAdd);
    }
}

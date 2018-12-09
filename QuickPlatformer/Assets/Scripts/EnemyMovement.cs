using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float jumpSpeed = 18f;
    Rigidbody2D enemyRB;
    private float lastJumpTime;
    private float jumpDelay = 5f;

	// Use this for initialization
	void Start () {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRB.constraints = RigidbodyConstraints2D.FreezePositionX;
	}
	
	// Update is called once per frame
	void Update () {
        JumpTimer();
	}

    private void JumpTimer()
    {
        if (Time.time > lastJumpTime + jumpDelay)
        {
            enemyRB.velocity = new Vector2(0f, jumpSpeed);
            lastJumpTime = Time.time;
        }
    }
}

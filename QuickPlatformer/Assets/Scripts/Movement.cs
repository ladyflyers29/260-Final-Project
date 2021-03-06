﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Movement : MonoBehaviour {

    //Config
    [SerializeField] float runSpeed = 20f;
    [SerializeField] float jumpSpeed = 5f;

    //State
 //   bool isAlive = true;

    //Cached component references
    Rigidbody2D rb;
    Animator an;
    CapsuleCollider2D bodyCol;
    BoxCollider2D feetCol;
    

    //methods
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        bodyCol = GetComponent<CapsuleCollider2D>();
        feetCol = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
//        if (!isAlive) { return; }

        Run();
        Jump();
        FlipSprite();
	}

    private void Run()
    {
        float hMovement = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between from -1 to +1
        Vector2 playerVelocity = new Vector2(hMovement * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        an.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if(!feetCol.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 JumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rb.velocity += JumpVelocityToAdd;

        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x) * 5, 5f);
        }
    }

    //void Die()
    //{
    //    if (rb.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")));
    //    {
           
            
    //    }
    //}

}

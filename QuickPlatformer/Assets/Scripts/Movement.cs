using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Movement : MonoBehaviour {

    [SerializeField] float runSpeed = 20f;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Run();
        Flip();
	}

    private void Run()
    {
        float hMovement = CrossPlatformInputManager.GetAxis("Horizontal"); //value is between from -1 to +1
        Vector2 playerVelocity = new Vector2(hMovement * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }
    private void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x) * 5, 5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;

    public bool isGrounded;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove(){
        //Control
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            Jump();
        }
        
        //Animation
        //Player Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipPlayer(){
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump(){
        //Jumping code
        isGrounded = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Collision");
        if (col.gameObject.tag == "ground"){
            isGrounded = true;
        }
    }
}


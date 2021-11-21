using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    Animator m_Animator;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_health.death == false)
        {
            PlayerMove();
            PlayerRayCast();
        }
    }

    void PlayerRayCast(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.collider != null && hit.distance < 0.51f){
            if (hit.collider.tag == "ground" && isGrounded == false)
            {
                isGrounded = true;
                m_Animator.SetBool("IsJumping", false);
               
            }
        }
        if (hit.collider != null && hit.distance > 0.51f)
        {
            if (hit.collider.tag == "ground")
            {
                isGrounded = false;
            }
        }
    }
    void PlayerMove(){
        //Control
        moveX = Input.GetAxis("Horizontal");
        m_Animator.SetFloat("Speed", Mathf.Abs(moveX * playerSpeed));
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            m_Animator.SetBool("IsJumping", true);
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
        SoundManager.soundManager.PlaySound("playerJump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
}


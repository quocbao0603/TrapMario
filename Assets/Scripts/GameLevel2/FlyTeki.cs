using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTeki : MonoBehaviour
{
    public int moveX = -1;
    public int speed = 2;
    public int another_speed = 7;
    public int force = 1000;

    private bool allow_move = false;

    // Start is called before the first frame update
    void Start()
    {
        Fly();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }

        if (allow_move)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0) * speed;
        }
        RayCast();
    }

    private void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveX, 0));
        RaycastHit2D r_hit = Physics2D.Raycast(transform.position, new Vector2(-moveX, 0));
        if (hit.collider != null && hit.distance < 0.48f && hit.collider.gameObject.tag != "empty")
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerHealthLevel2.Die();
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
                moveX *= -1;
                speed = another_speed;
            }
        }

        // Reverse hit, check die for player
        if (r_hit.collider != null && r_hit.distance < 0.48f)
        {
            if (r_hit.collider.gameObject.tag == "Player")
            {
                PlayerHealthLevel2.Die();
            }
        }
    }

    void Fly()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool down = gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0; // fallen 
        if (collision.gameObject.name == "FlyTekiBlock" && down == true)
        {
            moveX = -1;
            allow_move = true;
        }
    }

}

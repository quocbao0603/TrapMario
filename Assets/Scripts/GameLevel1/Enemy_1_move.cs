using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_move : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (gameObject.transform.position.x < -4.5){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player_health.Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki_1_controller : MonoBehaviour
{
    public int force = 30;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (gameObject.transform.position.y > 10){
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        rb.isKinematic = false;
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            Fly();
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player_health.Die();
        }
    }

    void Fly()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }
}

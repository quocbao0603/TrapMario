using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    public int force = 3000;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    // Update is called once per frame
    void Update()
    {
         if (gameObject.transform.position.x < 40){
             Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       rend.enabled = true;
       FlyToLeft();
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player"))
        {
            rend.enabled = true;
            player_health.Die();
        }
    }

    void FlyToLeft()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left  * force);
    }
}

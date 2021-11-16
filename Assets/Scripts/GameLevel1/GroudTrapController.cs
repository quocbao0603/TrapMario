using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class GroudTrapController : MonoBehaviour
{
    public int force = 1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is in the trap");
        rb.isKinematic = false;
        if (collision.gameObject.tag == "Player"){
            Debug.Log("Drop active");
            DropDown();
        }
    }
    void DropDown()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * force);
    }
  
}

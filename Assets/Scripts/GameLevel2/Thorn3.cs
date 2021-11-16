using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            // Destroy thorn when fall too low.
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player on collision thorn 3");
            PlayerHealthLevel2.Die();
        } else if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}

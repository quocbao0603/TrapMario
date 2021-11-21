using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneThorn3 : MonoBehaviour
{
    public GameObject thorn;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (thorn != null)
            {
                // Increase gravity to let trap down.
                thorn.GetComponent<Rigidbody2D>().mass = 100;
                thorn.GetComponent<Rigidbody2D>().gravityScale = 10;
            }
        }
    }
}

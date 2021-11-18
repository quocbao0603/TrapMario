using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneThorn3 : MonoBehaviour
{
    public GameObject thorn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
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

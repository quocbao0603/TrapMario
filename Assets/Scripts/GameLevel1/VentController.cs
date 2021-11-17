using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentController : MonoBehaviour
{
    Collider m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //m_Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("on danger area");
        if (other.gameObject.CompareTag("enemy"))
        {
            //Debug.Log("active");
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        // if (other.gameObject.CompareTag("Player"))
        // {
        //     Debug.Log("on Vent");
        // }

        
    }
}

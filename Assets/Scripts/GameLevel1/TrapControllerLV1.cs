using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TrapControllerLV1 : MonoBehaviour
{
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }


    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trap triggered");
        if (collision.gameObject.tag == "Player")
        {
            rend.enabled = true;
            Debug.Log($"{name} is Triggered");
            player_health.Die();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSideBlock : MonoBehaviour
{
    public Renderer rend;
    static public bool isActive = false;
    void Start()
    {
        OneSideBlock.isActive = false;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    private void Update()
    {
        RayCast();
    }

    void RayCast()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        //if (isActive && hit.collider != null && hit.distance < 0.8f)
        //{
        //    if (hit.collider.tag == "Player")
        //    {
        //        Debug.Log($"{name}Invisible block hit player");
        //        rend.enabled = true;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive == true && collision.gameObject.tag == "Player")
        {
            rend.enabled = true;
        }
    }

}

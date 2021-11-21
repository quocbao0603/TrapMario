using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour
{
    public int jump_force = 500;

    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null && hit.distance < 0.5f)
        {
            if (hit.collider.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force);
            }
        }
    }

}

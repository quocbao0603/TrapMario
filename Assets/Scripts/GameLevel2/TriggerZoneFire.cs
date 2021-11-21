using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneFire : MonoBehaviour
{
    public GameObject fire;
    public int fireSpeed = 40;

    // Update is called once per frame
    void Update()
    {
        if (fire != null)
        {
            if (fire.GetComponent<Transform>().position.y > 100)
            {
                Destroy(fire);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (fire != null)
                fire.GetComponent<Rigidbody2D>().velocity = Vector2.up * fireSpeed;
        }
    }
}

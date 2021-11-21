using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2DAndDie : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealthLevel2.Die();
        }
    }
}

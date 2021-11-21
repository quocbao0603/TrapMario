using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlyTeki : MonoBehaviour
{
    public GameObject fly_teki;
    // Start is called before the first frame update
    void Start()
    {
        fly_teki.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fly_teki.SetActive(true);
        }
    }
}

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive == true && collision.gameObject.tag == "Player")
        {
            rend.enabled = true;
        }
    }

}

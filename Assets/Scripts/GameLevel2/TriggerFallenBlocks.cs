using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallenBlocks : MonoBehaviour
{
    public int gravity_fallen = 2;
    public GameObject blocks;
    // Start is called before the first frame update
    void Start()
    {
        blocks.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (blocks != null && blocks.transform.position.y < -100)
        {
            Destroy(blocks);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (blocks != null)
                blocks.GetComponent<Rigidbody2D>().gravityScale = gravity_fallen;
        }
    }
}

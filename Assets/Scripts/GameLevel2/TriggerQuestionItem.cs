using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestionItem : MonoBehaviour
{
    public int gravity_fallen = 3;
    public GameObject fallen_ground;
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
            Destroy(gameObject);
            fallen_ground.GetComponent<Rigidbody2D>().gravityScale = gravity_fallen;
            fallen_ground.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            fallen_ground.GetComponent<Rigidbody2D>().freezeRotation = true;
        }
    }
}

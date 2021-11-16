using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneShooting : MonoBehaviour
{
    public int shooting_speed = 30;
    public GameObject shooting;
    // Start is called before the first frame update
    void Start()
    {
        shooting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting.transform.position.x < -100)
        {
            Destroy(shooting);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shooting.SetActive(true);
            shooting.GetComponent<Rigidbody2D>().velocity = Vector2.left * shooting_speed;
        }
    }
}

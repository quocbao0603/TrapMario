
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class Thorn_1_Control : MonoBehaviour
{
     public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }


    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.enabled = true;
            player_health.Die();
        }
    }
}

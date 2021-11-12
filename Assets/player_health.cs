using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
       
    }

    void Die(){
        //Debug.Log("Player has died");
        SceneManager.LoadScene("Prototype_1");
        //yield return null; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events; 

public class player_health : MonoBehaviour
{

 
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //fall in a hole
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }
  

    public static void Die(){
        Debug.Log("Player has died");
        // TODO: Pause all things in 2-3 seconds depends on the length of "playerDie" sound
        SoundManager.soundManager.PlaySound("playerDie");

        DataManagement.dataManagement.dies_counter++; // increase number of die time to show at game-over UI
        SceneManager.LoadScene("GameOver");
        //yield return null; 
    }

    public static void Win(){
        Debug.Log("Player has won");
        //DataManagement.dataManagement.wins_counter++; // increase number of win time to show at game-over UI
        SceneManager.LoadScene("GameLevel2");
        //yield return null; 
    }

}

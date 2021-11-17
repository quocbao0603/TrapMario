using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthLevel2 : MonoBehaviour
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

    public static void Die()
    {
        // Just for testing sound,
        // TODO: Pause all things in 2-3 seconds depends on the length of "playerDie" sound
        SoundManager.soundManager.PlaySound("playerDie");
        SceneManager.LoadScene("GameLevel2");

        //DataManagement.dataManagement.dies_counter++; // increase number of die time to show at game-over UI
        //SceneManager.LoadScene("GameOver");
        //yield return null; 
    }

    public static void Win()
    {
        //DataManagement.dataManagement.wins_counter++; // increase number of win time to show at game-over UI
        Debug.Log("Player win in level 2");
        SceneManager.LoadScene("MainMenu");
        //yield return null; 
    }
}

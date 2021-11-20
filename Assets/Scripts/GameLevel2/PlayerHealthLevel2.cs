using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthLevel2 : MonoBehaviour
{
    static public bool death = false;
    static private Animator animator;
    static private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        player = gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death == false)
        {
            //fall in a hole
            if (gameObject.transform.position.y < -7)
            {
                Die();
            }
        }
    }

    public static void Die()
    {
        if (death == false)
        {
            // Just for testing sound,
            // TODO: Pause all things in 2-3 seconds depends on the length of "playerDie" sound
            animator.SetTrigger("Death");
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            BackgroundMusicManager.TurnOff();
            SoundManager.soundManager.PlaySound("playerDie");
            death = true;
            DataManagement.dataManagement.dies_counter++; // increase number of die time to show at game-over UI
        }
    }

    public void FallDown()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // let it fall down.
    }

    public void RestartLevel()
    {
        // Save previous scene to continue 
        PlayerPrefs.SetString("previous_scene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

    public static void Win()
    {
        // Update level to unlock map in MapSelection scene
        MapUIManager.instance.UpdateCurrentMapIndex(2);
        //Load win UI before changing scene
        SceneManager.LoadScene("WinUI");
    }
}

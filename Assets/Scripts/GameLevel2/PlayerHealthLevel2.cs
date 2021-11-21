using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthLevel2 : MonoBehaviour
{
    static public bool death = false;
    static private Animator animator;
    static private GameObject player;
    static private ItemCollector itemCollector;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        player = gameObject;
        animator = GetComponent<Animator>();
        itemCollector = GetComponent<ItemCollector>();
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
            animator.SetTrigger("Death");
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            BackgroundMusicManager.TurnOff();
            SoundManager.soundManager.PlaySound("playerDie");
            death = true;
            DataManagement.dataManagement.dies_counter++; // increase number of die time to show at game-over UI

            // Update number of coins 
            MapUIManager.instance.UpdateCurrentStar(1, itemCollector.coinCount);
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
        MapUIManager.instance.UpdateFinishStar(1, itemCollector.coinCount);
        MapUIManager.instance.UpdateCurrentMapIndex(2);
        //Load win UI before changing scene
        SceneManager.LoadScene("WinUI");
    }
}

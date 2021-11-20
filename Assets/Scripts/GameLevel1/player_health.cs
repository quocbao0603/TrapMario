using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events; 

public class player_health : MonoBehaviour
{
    static public bool death = false;
    static private Animator animator;
    static private GameObject player;
    static private ItemCollector itemCollector;
    public bool updateOn = true;
    
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
        //fall in a hole
        
        if (death == false && gameObject.transform.position.y < -7)
            {
                Die();
            }
        
    }

    public static void Die(){
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

            // Update number of coins 
            MapUIManager.instance.UpdateCurrentStar(0, itemCollector.coinCount);
        }
    }

    public void FallDown()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // let it fall down.
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetString("previous_scene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

    public static void Win(){
        // Update level to unlock map in MapSelection scene
        MapUIManager.instance.UpdateFinishStar(0, itemCollector.coinCount);
        MapUIManager.instance.UpdateCurrentMapIndex(1);
        MapUIManager.instance.EnableCanvas();
        SceneManager.LoadScene("MapSelection");
    }
}

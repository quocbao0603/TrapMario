using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int dies_counter = 0;
    // Start is called before the first frame update
    void Start() {
        dies_counter++;
        Debug.Log(dies_counter);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
        
    }
}

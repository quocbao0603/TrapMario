using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject dieCounterUI;
    // Start is called before the first frame update
    void Start() {
        Debug.Log(DataManagement.dataManagement.dies_counter);
    }

    // Update is called once per frame
    void Update()
    {
        int dies_counter = DataManagement.dataManagement.dies_counter;
        // Set number of dies timer to UI
        dieCounterUI.gameObject.GetComponent<Text>().text = ("x -" + dies_counter);
        if (Input.anyKeyDown)
        {
            if (!Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1)) { 
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void BackToMenuButton()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("MainMenu");
    }
}

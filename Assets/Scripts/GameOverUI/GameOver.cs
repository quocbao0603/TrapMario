using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //public bool updateOn = true;
    public GameObject dieCounterUI;
    // Start is called before the first frame update
    void Start() {
       
        //StartCoroutine (updateOff());
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
                SceneManager.LoadScene(PlayerPrefs.GetString("previous_scene"));
            }
        }
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //IEnumerator updateOff ()
    //{
    //    Debug.Log("updateOff");
    //    updateOn = false;
    //    yield return new WaitForSeconds (3.5f);
    //    updateOn = true;
    //}
}



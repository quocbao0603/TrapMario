using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUIController : MonoBehaviour
{
    public bool updateOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WinUIController Start");
        //SoundManager.soundManager.PlaySound("levelComplete");
        StartCoroutine (updateOff());
    }

    // Update is called once per frame
    void Update()
    {
        if (updateOn)
        {
            Debug.Log("WinUIController Update");
            //Update level to unlock map in MapSelection scene
            //MapUIManager.instance.UpdateCurrentMapIndex(1);
            MapUIManager.instance.EnableCanvas();
            SceneManager.LoadScene("MapSelection");
            
        }
    }

     IEnumerator updateOff ()
    {
       Debug.Log("updateOff");
       updateOn = false;
       yield return new WaitForSeconds (5);
       updateOn = true;
    }
}

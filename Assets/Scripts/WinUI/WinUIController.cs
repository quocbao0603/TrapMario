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
        SoundManager.soundManager.PlaySound("levelComplete");
        StartCoroutine (updateOff());
    }

    // Update is called once per frame
    void Update()
    {
        if (updateOn)
        {
            MapUIManager.instance.EnableCanvas();
            SceneManager.LoadScene("MapSelection");
            
        }
    }

    IEnumerator updateOff ()
    {
       updateOn = false;
       yield return new WaitForSeconds (5);
       updateOn = true;
    }
}

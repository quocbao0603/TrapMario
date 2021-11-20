using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetString("previous_scene", SceneManager.GetActiveScene().name);
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MapSelection");
    }
}

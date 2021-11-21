using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionMenuHolder;

    public Slider[] volumeSliders;

    public void Start()
    {
        PlayerPrefs.SetString("previous_scene", SceneManager.GetActiveScene().name);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        if (MapUIManager.instance != null)
            MapUIManager.instance.EnableCanvas();
        SceneManager.LoadScene("MapSelection");
    }

    public void OptionButton()
    {
        mainMenuHolder.SetActive(false);
        optionMenuHolder.SetActive(true);

    }

    public void BackButton()
    {
        mainMenuHolder.SetActive(true);
        optionMenuHolder.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        PlayerPrefs.SetFloat("master vol", value);
    }
    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("music vol", value);
        SoundManager.soundManager.SetMusicVolume(value);
    }
}

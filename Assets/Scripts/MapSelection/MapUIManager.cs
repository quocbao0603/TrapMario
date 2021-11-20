using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapUIManager : MonoBehaviour
{
    public static MapUIManager instance;

    public Canvas canvas;
    public GameObject mapSelectionPanel;
    public int current_map_index = 0;

    public int[] current_stars;
    public int[] finish_stars;
    public MapSelection[] maps;
    public Text[] lockedStarsText;
    public Text[] unlockedStarsText;
    public GameObject[] unlockedRightPanels;

    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        UpdateUnlockedStarUI();
    }

    private void UpdateUnlockedStarUI()
    {
        for (int i = 0; i < maps.Length; ++i)
        {
            if (maps[i].isUnlock == true)
            {
                if (finish_stars[i] >= 0)
                {
                    // Already finish level
                    // Show star image
                    // Show text
                    unlockedRightPanels[i].SetActive(true);
                    unlockedStarsText[i].text = finish_stars[i].ToString();
                } else
                {
                    // Not finish level
                    // Hidden image
                    // Hidden text
                    unlockedRightPanels[i].SetActive(false);
                }
            }
        }
    }

    public void PressMapButton(int mIndex)
    {
        if (maps[mIndex].isUnlock)
        {
            canvas.enabled = false;
            // Go to this map
            SceneManager.LoadScene(maps[mIndex].mapSceneLevel);
        } else
        {
            Debug.Log("You can not unlock this map!");
        }
    }

    public void PressBackButtonInMapSelection()
    {   
        SceneManager.LoadScene("MainMenu");
    }

    public void EnableCanvas()
    {
        canvas.enabled = true;
    }

    public void UpdateCurrentStar(int level, int star)
    {
        current_stars[level] = Math.Max(current_stars[level], star);
    }

    public void UpdateFinishStar(int level, int star)
    {
        finish_stars[level] = Math.Max(finish_stars[level], star);
    }

    public void UpdateCurrentMapIndex(int level)
    {
        current_map_index = Math.Max(current_map_index, level);
    }
}

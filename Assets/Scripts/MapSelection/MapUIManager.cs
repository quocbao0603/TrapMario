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
    public MapSelection[] maps;
    public Text[] lockedStarsText;
    public Text[] unlockedStarsText;

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

    private void UpdateStarUI()
    {
        for (int i = 0; i < maps.Length; ++i)
        {
            if (maps[i].isUnlock == false) {
                lockedStarsText[i].text = current_stars[i].ToString();
            } else
            {
                unlockedStarsText[i].text = current_stars[i].ToString();
            }
        }
    }

    public void PressMapButton(int mIndex)
    {
        Debug.Log("Clicked to map: " + mIndex);
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

    public void EnableCanvas()
    {
        canvas.enabled = true;
    }

    void UpdateCurrentStar(int level, int star)
    {
        current_stars[level] = Math.Max(current_stars[level], star);
    }

    public void UpdateCurrentMapIndex(int level)
    {
        current_map_index = Math.Max(current_map_index, level);
        Debug.Log("Update current map index: " + current_map_index);
    }
}

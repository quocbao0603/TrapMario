using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public bool isUnlock = false;
    public GameObject lockGo;
    public GameObject unlockGo;
    public string mapSceneLevel;
    public int mapIndex;
    public int mapStars;

    private void Update()
    {
        UnlockMap();
        UpdateMapStatus();
    }

    private void UpdateMapStatus()
    {
        unlockGo.gameObject.SetActive(isUnlock);
        lockGo.gameObject.SetActive(!isUnlock);
    }

    private void UnlockMap()
    {
        if (MapUIManager.instance.current_map_index >= mapIndex - 1)
        {
            isUnlock = true;
        } else
        {
            isUnlock = false;
        }
    }

}

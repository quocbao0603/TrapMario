using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    static private AudioSource audioSource;
    static private bool isPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void TurnOff()
    {
        isPlay = false;
        audioSource.Stop();
    }
}

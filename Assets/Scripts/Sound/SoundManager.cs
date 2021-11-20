using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    private AudioClip playerKill;
    private AudioClip playerJump;
    private AudioClip playerDie;
    private AudioClip playerCollect;

    private AudioSource audioSource;

    private void Awake()
    {
        Debug.Log("Sound Managemer Awake");
        if (soundManager == null)
        {
            DontDestroyOnLoad(gameObject);
            soundManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerKill = Resources.Load<AudioClip>("playerKill");
        playerJump = Resources.Load<AudioClip>("playerJump");
        playerDie = Resources.Load<AudioClip>("playerDie");
        playerCollect = Resources.Load<AudioClip>("playerCollect");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch(clip)
        {
            case "playerKill":
                audioSource.PlayOneShot(playerKill);
                break;
            case "playerJump":
                audioSource.PlayOneShot(playerJump);
                break;
            case "playerDie":
                audioSource.PlayOneShot(playerDie);
                break;
            case "playerCollect":
                audioSource.PlayOneShot(playerCollect);
                break;
            default:
                break;
        }
    }
}

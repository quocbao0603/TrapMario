using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{   
    public int coinCount = 0;
    [SerializeField] private Text coinText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            SoundManager.soundManager.PlaySound("playerCollect");
            Destroy(other.gameObject);
            coinCount++;
            coinText.text = "Score: " + coinCount;
        }
    }
}

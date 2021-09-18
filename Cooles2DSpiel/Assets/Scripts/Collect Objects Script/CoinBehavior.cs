using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] Text coinText;
    [SerializeField] AudioClip coinSFX;
    AudioSource audiosrc;
    int coins;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Coin"))
        {
            audiosrc.PlayOneShot(coinSFX);
            coins++;
            if (coins == 100)
            {
                coins = 0;
                //LifeUp
            }
            coinText.text = coins.ToString();
            Destroy(gameObject);
        }
    }
}

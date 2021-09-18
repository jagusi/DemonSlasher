using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    AudioSource audiosrc;
    HudBehavior hud;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc =GetComponent<AudioSource>();
        GameObject gameScriptObject = GameObject.FindGameObjectWithTag("Hud");
        hud = gameScriptObject.GetComponent<HudBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            //audiosrc.PlayOneShot(coinSFX);
            hud.CoinUp();
            Destroy(gameObject);
        }
    }
}

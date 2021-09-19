using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] Image runeImage;
    AudioSource audiosrc;
    HudBehavior hud;
    [SerializeField] bool itsArune;
    [SerializeField] Canvas winCanvas;
    int runes;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc =GetComponent<AudioSource>();
        GameObject gameScriptObject = GameObject.FindGameObjectWithTag("Hud");
        hud = gameScriptObject.GetComponent<HudBehavior>();
        runes = 0;
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
            Destroy(gameObject);
            if (itsArune)
            {
                runes++;
                runeImage.color = gameObject.GetComponent<SpriteRenderer>().color;
            }
            else
            {
                hud.CoinUp();
            }
            if (runes==4)
            {
                Time.timeScale = 0;
                winCanvas.enabled = true;
            }
        }
    }
}

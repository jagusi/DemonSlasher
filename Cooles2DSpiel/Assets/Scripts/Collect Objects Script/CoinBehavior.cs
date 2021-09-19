using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    GameObject audioCntrlGameObject;
    AudioController audioCntrl;
    [SerializeField] Image runeImage;
    HudBehavior hud;
    [SerializeField] bool itsArune;
<<<<<<< HEAD
=======
    [SerializeField] Canvas winCanvas;
    int runes;
>>>>>>> f14deb8b3c765d57922b5599538d77fecc3f3df6
    // Start is called before the first frame update
    void Start()
    {
        audioCntrlGameObject = GameObject.FindGameObjectWithTag("AudioController");
        audioCntrl = audioCntrlGameObject.GetComponent<AudioController>();
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
            audioCntrl.PlaySFXHit(2);
            Destroy(gameObject);
            if (itsArune)
            {
                hud.RuneUp();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int playerHp = 3;
    Animator anim;
    Transform checkpoint;
    [SerializeField]Transform startPosition;
    [SerializeField] HudBehavior hud;
    [SerializeField] AudioController audioCntrl;

    public int GetPlayerHP()
    {
        return playerHp; 
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHp <= 0)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("AttackingEnemy"))
        {
            playerHp--;
            //hud.LifeChange(-1);
            anim.SetBool("hurt", true);
            audioCntrl.PlaySFXHit(1);
        }
    }
    void Falling()
    {
        playerHp--;
        hud.LifeChange(-1);
        if(playerHp >= 1 && checkpoint == null)
        {
            transform.position = startPosition.position;
        }
        if (playerHp >= 1 && checkpoint != null)
        {
            transform.position = checkpoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Speicher Flaggen position falls man runterfällt für Respawn 
        if (collision.gameObject.CompareTag("ColliderFlag"))
        {
            checkpoint = collision.gameObject.transform;
        }
        //Falls man runterfällt
        if (collision.gameObject.CompareTag("ColliderFalling"))
        {
            Falling();
        }
    }
}

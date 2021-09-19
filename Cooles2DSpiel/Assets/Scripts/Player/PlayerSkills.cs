using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    Animator anim;
    [SerializeField] float mouseLeftKlick;
    [SerializeField] GameObject enemyGameobject;
    [SerializeField] AudioController audioCntrl;
     private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if(mouseLeftKlick == 1)
        {
            anim.SetTrigger("attack");
            audioCntrl.PlaySFXHit(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        mouseLeftKlick =  Input.GetAxisRaw("Fire1");
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
   
    }
}

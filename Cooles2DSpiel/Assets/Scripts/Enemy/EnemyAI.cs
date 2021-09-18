using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] int distance = 3;
    [SerializeField] float distanceVector;
    [SerializeField] int enemyHealth = 3;
    Animator anim;
    SpriteRenderer spriteRenderer; 
    bool goToLeft = true;
    Vector2 targetVector;
    Rigidbody2D rb;
    Vector2 startingPos;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
  
    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {

      
    }
    //Bewegung
    void Move()
    {
        //nach links bewegen
        if (goToLeft == true)
        {
            targetVector = Vector2.left;
            spriteRenderer.flipX = true ;
        }
        //nach Rechts bewegen
        else if (goToLeft == false)
        {
            targetVector = Vector2.right;
            spriteRenderer.flipX = false;
        }
        if (targetVector != null)
        {
            //rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + targetVector * Time.fixedDeltaTime);
            rb.velocity = targetVector*moveSpeed * Time.deltaTime; 
            distanceVector = Vector2.Distance(startingPos, transform.position);
            
            if (distanceVector >= distance && goToLeft == true)
            {
                goToLeft = false;
            }
            else if (distanceVector <= 0.2 && goToLeft == false)
            {
                goToLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Sword")
        {
            enemyHealth -= 1;
            anim.SetTrigger("hurt");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        
    }
}

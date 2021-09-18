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
    bool enemyDead = false;
    Animator anim;
    SpriteRenderer spriteRenderer; 
    bool goToLeft = true;
    Vector2 targetVector;
    Rigidbody2D rb;
    Vector2 startingPos;
    float timer = 0f;
    float waitTime = 3f;
    bool timeStopped = false;
    // Start is called before the first frame update
    public bool IsEnemyDead()
    {
        return enemyDead;
    }                  
    public void StopTime()
    {
        timeStopped = true;
    }
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
        if(enemyDead == false && timeStopped == false)
        {
            Move();
        }
      
        
    }
    // Update is called once per frame
    void Update()
    {

      if(enemyHealth <= 0)
        {
            anim.SetTrigger("dead");
            timer += Time.deltaTime;
            if(timer >= waitTime)
            {
                Destroy(gameObject);
            }
            enemyDead = true;
        }
        if (timeStopped == true)
        {
            anim.SetBool("timeStopped", true);
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timer = 0;
                timeStopped = false;
                anim.SetBool("timeStopped", false);
            }
        }
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
        if(collision.name == "Sword" && enemyHealth >= 0)
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

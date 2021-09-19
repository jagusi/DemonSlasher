using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    Transform player;
    [SerializeField] float aggroRange = 6f;
    [SerializeField] float distanceToPlayerX;
    [SerializeField] float distanceToPlayerY;
    [SerializeField] float moveSpeed = 180;
    [SerializeField] int distance = 3;
    [SerializeField] float distanceVector;
    [SerializeField] int enemyHealth = 3;
    [SerializeField] float attackRange = 2.2f;
    bool enemyDead = false;
    Animator anim;
    SpriteRenderer spriteRenderer;
    bool goToLeft = true;
    Vector2 targetVector;
    Rigidbody2D rb;
    Vector2 startingPos;
    [SerializeField] float timer = 0f;
    [SerializeField] float waitTime = 3f;
    bool timeStopped = false;
    GameObject playerObject;

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
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        anim = GetComponent<Animator>();
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //?ndere Farbe um zu zeigen das man es Interagierbar ist
    private void OnMouseEnter()
    {
        if (!enemyDead)
            spriteRenderer.color = Color.red;
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (enemyDead == false && timeStopped == false && !IsPlayerNear())
        {
            Move();
        }
        if (enemyDead == false && IsPlayerNear() && timeStopped == false)
        {
            ChasePlayer();
        }
    }
    void FlipSprite(bool flipSprite )
    {
        if(flipSprite == true)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, 180, rot.z);
            transform.rotation = Quaternion.Euler(rot);
        }
        else if(flipSprite == false)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, 0, rot.z);
            transform.rotation = Quaternion.Euler(rot);
        }
    }
    void ChasePlayer()
    {
        // Wenn Player links vom Enemy ist 
        if (distanceToPlayerX >= -aggroRange && distanceToPlayerX <= 0 )
        {
            targetVector = Vector2.left;
            FlipSprite(true);
        }
        // Wenn Player rechts vom Enemy ist 
        else if (distanceToPlayerX <= aggroRange && distanceToPlayerX >= 0)
        {
            targetVector = Vector2.right;
            FlipSprite(false);
        }
        rb.velocity = (targetVector * moveSpeed * Time.fixedDeltaTime) + new Vector2(0, rb.velocity.y);
        float dist = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayerX >= -attackRange && distanceToPlayerX <= attackRange)
        {
            anim.SetTrigger("attacking");
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            anim.SetTrigger("dead");
            timer += Time.deltaTime;
            if (timer >= waitTime)
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
    bool IsPlayerNear()
    {
        distanceToPlayerX = player.transform.position.x - transform.position.x;
        distanceToPlayerY = player.transform.position.y - transform.position.y;

        if (distanceToPlayerX >= -aggroRange && distanceToPlayerX <= aggroRange && distanceToPlayerY >= -0.65 && distanceToPlayerY <= 1.25)
        {
            return true;
        }
        else
            return false;
    }
  

    //Nach links/rechts Roaming
    void Move()
    {
        //nach links bewegen
        if (goToLeft == true)
        {
            targetVector = Vector2.left;
            //spriteRenderer.flipX = true;
            FlipSprite(true);
        }
        //nach Rechts bewegen
        else if (goToLeft == false)
        {
            targetVector = Vector2.right;
            //spriteRenderer.flipX = false;
            FlipSprite(false);

        }
        if (targetVector != null)
        {

            rb.velocity = (targetVector * moveSpeed * Time.fixedDeltaTime) + new Vector2(0, rb.velocity.y);
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
        if (collision.name == "Sword" && enemyHealth >= 0)
        {
            enemyHealth -= 1;
            anim.SetTrigger("hurt");
        }
        else if (collision.gameObject.tag == "ColliderBarrier")
        {
            ChangeDirection();
        }
    }
    // Wenn an der Grenze zur Platform ist.
    void ChangeDirection()
    {
        if (goToLeft == false)
        {
            goToLeft = true;
        }
        else if (goToLeft)
        {
            goToLeft = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objects"))
        {
            ChangeDirection();
        }

    }
}
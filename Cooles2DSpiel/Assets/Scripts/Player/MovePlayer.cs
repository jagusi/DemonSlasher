using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] GameObject platformTileMap;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider2d;
    Vector2 moveVector;
    UnityEngine.Tilemaps.TilemapCollider2D platformTileCollider;
    float jumpValue;
    float moveHorizontal;
    bool nearLadder = false;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformTileCollider = platformTileMap.GetComponent<UnityEngine.Tilemaps.TilemapCollider2D>();
       
    }
    void Start()
    {
        
    }

    void Move()
    {
        // Bewegung und Flip des Sprites 
        if (jumpValue == 1 && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpValue * jumpVelocity * Time.fixedDeltaTime);
            anim.SetTrigger("jump");
        }
        if (moveHorizontal != 0)
        {
            rb.velocity = new Vector2(moveHorizontal * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetBool("run", true);
            if (moveHorizontal == -1)
            {

                Vector3 rot = transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, 180, rot.z);
                transform.rotation = Quaternion.Euler(rot);
            }
            //spriteRenderer.flipX = true;
            else
            {
                Vector3 rot = transform.rotation.eulerAngles;
                rot = new Vector3(rot.x, 0, rot.z);
                transform.rotation = Quaternion.Euler(rot);
            }
                //spriteRenderer.flipX = false;
        }
        else
        {
            anim.SetBool("run", false);
        }
    }
    private void FixedUpdate()
    {
        Move();
        // Leiter nutzen
        if (nearLadder == true)
        {
            Climb();
        }

    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
       
    }
    void GetInput()
    {
        jumpValue = Input.GetAxisRaw("Jump");
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }
    void Climb()
    {
        anim.SetBool("climb", nearLadder);
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime*2);
    }
    // Nur Springen wenn auf Platform ist 
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d =  Physics2D.BoxCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size, 0f, Vector2.down , .1f, platformsLayerMask);
       return raycastHit2d.collider != null; 
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check ob man nähe der Leiter ist 
        if (collision.gameObject.CompareTag("Ladder"))
        {
            nearLadder = true;
        }
       // Check ob man von Leiter zur Platform wechseln kann
        if(collision.name == "Platform Entry")
        {
            platformTileCollider.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Check ob man nicht mehr in der nähe der Leiter ist  
        if (collision.gameObject.CompareTag("Ladder"))
        {
            nearLadder = false;
            anim.SetBool("climb", nearLadder);
        }
        //Check ob man nicht mehr in der nähe der Platform ist  
        if (collision.name == "Platform Entry")
        {
            platformTileCollider.enabled = true;
        }
    }

}

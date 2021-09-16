using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float jumpVelocity = 10f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] private LayerMask platformsLayerMask;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private BoxCollider2D boxCollider2d;
    Rigidbody2D rb;
    float jumpValue;
    float moveHorizontal;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {

           if (jumpValue == 1  && IsGrounded())
            {
             rb.velocity = new Vector2(0, jumpValue * jumpVelocity *Time.fixedDeltaTime);
             anim.SetTrigger("jump");
            }
           if(moveHorizontal != 0)
            {
             rb.velocity = new Vector2(moveHorizontal * walkSpeed * Time.fixedDeltaTime,rb.velocity.y);
             anim.SetBool("run",true);
            if (moveHorizontal == -1)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;
        }
           else
            {
            anim.SetBool("run", false);
            }

    }
    // Update is called once per frame
    void Update()
    {            
        jumpValue = Input.GetAxisRaw("Jump");
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }
    // Nur Springen wenn auf Platform ist 
    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2d =  Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down , .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
       return raycastHit2d.collider != null; 
    }
}

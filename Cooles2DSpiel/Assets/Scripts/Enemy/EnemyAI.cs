using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] int distance = 3;
    bool goToLeft = true;
    Vector2 targetVector;
    Rigidbody2D rb;
    Vector2 startingPos;
    // Start is called before the first frame update
    private void Awake()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
  
    private void FixedUpdate()
    {
        Roam();
    }
    // Update is called once per frame
    void Update()
    {

      
    }
    void Roam()
    {
        //nach links bewegen
        if (goToLeft == true)
        {
            targetVector = Vector2.left;
        }
        //nach Rechts bewegen
        else if (goToLeft == false)
        {
            targetVector = Vector2.right;
        }
        if (targetVector != null)
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + targetVector * Time.fixedDeltaTime);
            float distanceVector = Vector2.Distance(startingPos, transform.position);
            
            if (distanceVector >= distance && goToLeft == true)
            {
                goToLeft = false;
            }
            else if (distanceVector <= 0.1 && goToLeft == false)
            {
                goToLeft = true;
            }
        }
    }
}

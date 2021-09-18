using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
   [SerializeField] float distance = 2f;
    Vector2 startPos;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        direction = Vector2.up;
    }
   
    // Update is called once per frame
    void Update()
    {
        Vector2 transPos = transform.position;
        transform.position = transPos + direction * Time.deltaTime;
        float actualDistance = Vector2.Distance(startPos, transform.position);
        if(actualDistance >= distance)
        {
            direction = Vector2.down;
        }
        else if(actualDistance <= 0.2)
        {
            direction = Vector2.up;
        }
        
    }
}

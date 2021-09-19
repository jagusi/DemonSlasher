using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    [SerializeField] float distance = 2f;
    [SerializeField] float waitTime = 3f;
    [SerializeField] float speed;
     UnityEngine.Tilemaps.Tilemap tileMap;
    Vector2 startPos;
    Vector2 direction;
    bool timeStopped = false;
    [SerializeField]float timer = 0f;
    
    public bool IsTimeStopped()
    {
        return timeStopped;
    }
    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<UnityEngine.Tilemaps.Tilemap>();
        startPos = transform.position;
        direction = Vector2.up;
    }
    //?ndere Farbe wenn Maus drauf geht 
    private void OnMouseEnter()
    {
        tileMap.color = Color.red;
    }
    private void OnMouseExit()
    {
        tileMap.color = Color.white;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!timeStopped)
        {
            MovePlatform();
        }
        if (timeStopped)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timer = 0;
                timeStopped = false;
            }
        }
    }
    public void StopTime()
    {
        timeStopped = true;
    }
    void MovePlatform()
    {
        Vector2 transPos = transform.position;
        transform.position = transPos + direction * Time.deltaTime * speed;
        float actualDistance = Vector2.Distance(startPos, transform.position);
        if (actualDistance >= distance)
        {
            direction = Vector2.down;
        }
        else if (actualDistance <= 0.2)
        {
            direction = Vector2.up;
        }
    }
}

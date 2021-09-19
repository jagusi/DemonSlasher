using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    [SerializeField] Camera camera;
    EnemyAI enemyAiScript;
    MoveablePlatform moveablePlatformScript;
    private void Awake()
    {
       // enemyAiScript = GetComponent<EnemyAI>();
    }
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 rayCastPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector2.zero);
            
            if(hit.collider.gameObject.CompareTag("Enemy"))
            {
                
                enemyAiScript = hit.collider.gameObject.GetComponent<EnemyAI>();
                if (!enemyAiScript.IsEnemyDead() )
                    enemyAiScript.StopTime();
            }
             if (hit.collider.gameObject.CompareTag("MoveableObject"))
            {
                moveablePlatformScript = hit.collider.gameObject.GetComponent<MoveablePlatform>() ;
                if (!moveablePlatformScript.IsTimeStopped())
                {
                    moveablePlatformScript.StopTime();
                }
                
            }
        }
    }
}

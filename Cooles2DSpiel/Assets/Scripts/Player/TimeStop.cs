using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] HudBehavior hud;
    [SerializeField] float waitTime = 5f;
    float timer = 0f;
    bool timeStopped = false;
    
    EnemyAI enemyAiScript;
    EnemyAttacking enemyAttackingScript;
    MoveablePlatform moveablePlatformScript;
   
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStopped == true)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timeStopped = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && timeStopped == false)
        {
            Vector2 rayCastPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector2.zero);

            if (hit.collider.gameObject.CompareTag("AttackingEnemy"))
            {

                enemyAttackingScript = hit.collider.gameObject.GetComponent<EnemyAttacking>();
                if (!enemyAttackingScript.IsEnemyDead())
                {
                    enemyAttackingScript.StopTime();
                    hud.BatteryDown();
                    timeStopped = true;
                }
                    
            }
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                
                enemyAiScript = hit.collider.gameObject.GetComponent<EnemyAI>();
                if (!enemyAiScript.IsEnemyDead())
                {
                    enemyAiScript.StopTime();
                    hud.BatteryDown();
                    timeStopped = true;
                }
                    
            }
             if (hit.collider.gameObject.CompareTag("MoveableObject"))
            {
              
                moveablePlatformScript = hit.collider.gameObject.GetComponent<MoveablePlatform>() ;
                if (!moveablePlatformScript.IsTimeStopped())
                {
                    moveablePlatformScript.StopTime();
                    hud.BatteryDown();
                    timeStopped = true;
                }
            }
        }
    }
}

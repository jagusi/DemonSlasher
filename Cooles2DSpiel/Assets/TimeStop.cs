using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    [SerializeField] Camera camera;
    EnemyAI enemyAiScript;
    
    private void Awake()
    {
        enemyAiScript = GetComponent<EnemyAI>();
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
                if (!enemyAiScript.IsEnemyDead())
                    enemyAiScript.StopTime();
            }
        }
    }
}

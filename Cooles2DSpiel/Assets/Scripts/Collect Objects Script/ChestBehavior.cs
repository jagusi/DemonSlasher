using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBehavior : MonoBehaviour
{
    Animator anim;
    [SerializeField] Image key;
    [SerializeField] GameObject runeRed;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (key.enabled)
            {
                anim.SetBool("key", true);
                if (gameObject.name.Equals("GoldenChest") && i==0)
                {
                    Instantiate(runeRed, new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                    i = 1;
                }
            }
        }
    }
}

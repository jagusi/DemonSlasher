using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] Image silverKey, goldenKey;
    string key;
    bool silverk = false, goldenk = false;
    // Start is called before the first frame update
    void Start()
    {
        key = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (key.Equals("SilverKey"))
            {
                silverKey.enabled = true;
                silverk = true;
            }
            if (key.Equals("GoldenKey"))
            {
                goldenKey.enabled = true;
                goldenk = true;
            }
            Destroy(gameObject);
        }
    }
}

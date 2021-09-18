using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudBehavior : MonoBehaviour
{
    [SerializeField] Text coinText, lifeText;
    int lifes, coins;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinUp()
    {
        coins++;
        if (coins == 100)
        {
            coins = 0;
            LifeChange(1);
        }
        coinText.text = coins.ToString();
    }
    public void LifeChange(int i)
    {
        lifes += i; ;
        lifeText.text = lifeText.ToString();
    }
}

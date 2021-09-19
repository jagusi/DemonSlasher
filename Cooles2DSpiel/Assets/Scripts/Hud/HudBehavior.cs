
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudBehavior : MonoBehaviour
{
    [SerializeField] Text coinText, lifeText;
    [SerializeField] List<Image> batteryImage;
    int lifes, coins,counter;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        coins = 0;
        counter = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CoinUp()
    {
        coins++;
        if (coins == 30)
        {
            coins = 0;
            LifeChange(1);
        }
        coinText.text = coins.ToString();
    }
    public void LifeChange(int i)
    {
        lifes += i; ;
        lifeText.text = lifes.ToString();
    }
    public void BatteryDown()
    {
        foreach (var image in batteryImage)
        {
            image.enabled = false;
        }
        InvokeRepeating("BatteryUp", 1.0f, 1.0f);
    }
    void BatteryUp()
    {
        batteryImage[counter].enabled = true;
        --counter;
        if (counter>0)
        {
            counter = 4;
            CancelInvoke();
        }
    }
}


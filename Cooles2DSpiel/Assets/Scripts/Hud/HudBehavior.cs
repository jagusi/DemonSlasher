
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudBehavior : MonoBehaviour
{
    [SerializeField] Text coinText, lifeText;
    [SerializeField] List<Image> batteryImage;
     PlayerStats playerStats;
    int runes;
    [SerializeField] Canvas winCanvas;
     
    int lifes, coins,counter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerStats = playerGameObject.GetComponent<PlayerStats>();
        lifes = playerStats.GetPlayerHP();
        coins = 0;
        counter = 4;
        runes = 0;
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
        if (counter<0)
        {
            counter = 4;
            CancelInvoke();
        }
    }
    public void RuneUp()
    {
        runes++;
        if (runes == 4)
        {
            winCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}


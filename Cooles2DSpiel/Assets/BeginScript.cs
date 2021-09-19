using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginScript : MonoBehaviour
{
    int i;
    float returnbuttonklick;
    [SerializeField] Text senseiText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        returnbuttonklick = 0f;
        i = 0;
    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ++i;
            ChangeText();
        }
    }
    void ChangeText()
    {
        switch (i)
        {
            case 1: senseiText.text = "Die Dämonen schlugen bereits vor 1000 Jahren Ihr Unwesen auf Erden."; break;
            case 2: senseiText.text = "Damals jedoch hatten Sie ihr eigenen kleinen Wohnort und ernährten Sich noch nicht von Menschenfleisch."; break;
            case 3: senseiText.text = "Dabei ist Menschenfleisch viel zu zäh... auf dem Grill ist es ganz gut."; break;
            case 4: senseiText.text = "Die einzige Möglichkeit die Dämonenplage zu beseitigen ist es in die Zeit zurück zureisen und die vier heiligen Coins zu finden."; break;
            case 5: senseiText.text = "Ich kann dich in die Zeit zurück schicken mein kleiner Grasshüpfer."; break;
            case 6: senseiText.text = "Aber sei gewarnt!"; break;
            case 7: senseiText.text = "Der Weg wird kein leichter sein, deswegen schenke ich dir nicht nur Weisheit mit auf deiner kleinen Reise."; break;
            case 8: senseiText.text = "*Pengu Sensei schwingt sein Zauberstab*"; break;
            case 9: senseiText.text = "Klick mit der rechten Maustaste auf deine Gegner um ihre Zeit zu stoppen."; break;
            case 10: Destroy(gameObject);Time.timeScale = 1; break;
            default:
                break;
        }
    }
}

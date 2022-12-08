using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public float levelTime; //Tijd van het level
    private bool isCounting = true; //Loopt de teller of niet
    public static int health = 3; //Het aantal levens van de speler
    public Image totalhealthBar; //De healthbar in volle staat
    public Image currenthealthBar; //De variabele healthbar
    public Text TimerText; //De timer text 


    private void Start()
    {
        levelTime = 40; //je hebt 40 seconden
        currenthealthBar.fillAmount = (float)health / 10; //De sprite bestaat uit 10 hartjes, we werken met 3 dus wordt hij gedeeld door 10
    }

    private void Update()
    {
        if (isCounting)
        { 
            //Hier weet het script hoe de timer werkt
            if (levelTime > 0)
            {
                levelTime -= Time.deltaTime;
                TimerText.text = Mathf.RoundToInt(levelTime).ToString();
            }

            else if (levelTime <= 0)
            {
                levelTime = 0;
                TimeIsOver();
                isCounting = false;
            }
        }

        if (health <= 0)
        {
            health = 3;
            SceneManager.LoadScene(0);
        }
    }

    //Bij deze functie krijgt de speler demage
    public void TakeDamage()
    {
        health--;
        ReloadLevel();
    }

    //Bij deze functie kan de speler een leven krijgen
    public void AddHealth()
    { if (health < 3)
        {
            health++;
            currenthealthBar.fillAmount = (float)health / 10;
        }
    }

    //Hier wordt er uitgevoerd wat er gebeurt als de ijd over is
    private void TimeIsOver()
    {
        health--;
        ReloadLevel();
    }

    //Hier reload hij de scene
    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}

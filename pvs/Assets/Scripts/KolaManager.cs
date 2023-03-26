using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KolaManager : MonoBehaviour
{
    public static KolaManager KolaManagerInstance;
    public int kolo = 1; // aktualni kolo
    float TimeRemaining;
    public float MaximumKoloMinutes;
    public TMP_Text RemainingTimeText;
    int seconds;
    int minutes;
    public inventory inv;

    private void Awake()
    {
        KolaManagerInstance = this;
        TimeRemaining = MaximumKoloMinutes * 60;
    }
    public void dalsikolo() // pridej jedno kolo
    {
        PlantManager.instance.updateplants();
        kolo ++;
        print(kolo);
        TimeRemaining = MaximumKoloMinutes * 60;
        inv.additemrandom();
    }
    private void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }
       
        if (TimeRemaining <= 0)
        {
            dalsikolo();
        }

        minutes = Mathf.FloorToInt(TimeRemaining / 60);
        seconds = Mathf.FloorToInt(TimeRemaining % 60);
        DisplayTime(TimeRemaining);
    }
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        RemainingTimeText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}

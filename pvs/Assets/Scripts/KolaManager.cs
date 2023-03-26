using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KolaManager : MonoBehaviour
{
    public static KolaManager KolaManagerInstance;
    public PerlinSpawn perlinSpawn;
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
        Dictionary<string, int> Spawn = perlinSpawn.Spawn();


        PlantManager.instance.updateplants();
        PlantManager.instance.BreedPlants();
        PlantManager.instance.CallAvilities();
        PlantManager.instance.SpreadPests();


        kolo++;
        print(kolo);
        TimeRemaining = MaximumKoloMinutes * 60;
        inv.additemrandom();

        Debug.Log(perlinSpawn.Spawn().Values);




        for (int i = 0; i < Spawn["Aphid"]; i++)
        {
            for (int t = 0; t < 200; t++)
            {
                int r = Random.Range(0, PlantManager.instance.allPlants.Count);

                if (PlantManager.instance.allPlants[r].infectedWith != "") continue;
                
                PlantManager.instance.allPlants[r].InfectWithPest("Aphid");

                break;
            }
        }

        for (int i = 0; i < Spawn["Snail"]; i++)
        {
            for (int t = 0; t < 200; t++)
            {
                int r = Random.Range(0, PlantManager.instance.allPlants.Count);

                if (PlantManager.instance.allPlants[r].infectedWith != "") continue;

                PlantManager.instance.allPlants[r].InfectWithPest("Snail");

                break;
            }
        }

        for (int i = 0; i < Spawn["Caterpillar"]; i++)
        {
            for (int t = 0; t < 200; t++)
            {
                int r = Random.Range(0, PlantManager.instance.allPlants.Count);

                if (PlantManager.instance.allPlants[r].infectedWith != "") continue;

                PlantManager.instance.allPlants[r].InfectWithPest("Caterpillar");

                break;
            }
        }

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

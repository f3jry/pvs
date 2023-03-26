using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager instance;


    public List<plant> allPlants;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void updateplants()
    {
        foreach (plant g in allPlants)
        {
            g.grow();
        }
    }


    public void BreedPlants()
    {
        foreach (plant g in allPlants)
        {
            g.Breed();
        }
    }

    public void CallAvilities()
    {

        foreach (plant g in allPlants)
        {
            g.gameObject.GetComponent<PlantAbilities>().CallEffects();



        }
    }

    public void SpreadPests()
    {

        foreach (plant g in allPlants)
        {
            g.PestEffects();

            g.SpreadPest();



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

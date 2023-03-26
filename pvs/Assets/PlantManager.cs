using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager instance;


    public List<plant> allPlants;
    public bool did;
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
        if(allPlants.Count > 0)
        {
            did = true;
        }
        if(allPlants.Count < 1)
        {
            Application.Quit();
            
        }
    }


    public void BreedPlants()
    {
        foreach (plant g in allPlants)
        {
            g.Breed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

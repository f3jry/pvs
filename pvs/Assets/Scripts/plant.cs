using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public List<PlantParent> pr = new List<PlantParent>();
    public KytkaPopUp pop;

    public List<GameObject> neighbours;

    int MaxHp = 6;
    int hp = 6;
    public float range = 1;
    int currentLevel = 0;
    PlantParent extparent;

    //3 not harvested, 2 NotHarvested+CannotBreed, 1 harvested waiting, 0 harvested
    public int harvestedLevel;

    KolaManager km;
    GridSystem gs;
    gridcursor gc;
    inventory inv;
    private void Awake()
    {
        gs = GridSystem.instance;
        gc = FindObjectOfType<gridcursor>();
        pop = FindObjectOfType<KytkaPopUp>();
        km = FindObjectOfType<KolaManager>();
        inv = FindObjectOfType<inventory>();

    }
    // Update is called once per frame
    private void Start()
    {
        PlantManager.instance.allPlants.Add(this);
        currentLevel = 0;
        GetComponent<PlantVisualManager>().UpdateSprites(currentLevel, "WIP", hp, pr);
    }
 
    public void takedamage(int damage)
    {
        if(hp - damage <= MaxHp)
        {
            hp -= damage;
        }
        else
        {
            hp = MaxHp;
        }
    }

    public void grow()
    {
        if (harvestedLevel < 3)
        {
            harvestedLevel += 1;
        }

        GetComponent<PlantVisualManager>().UpdateSprites(currentLevel, "WIP", hp, pr, (harvestedLevel < 2));



        if (currentLevel < 2)
        {
            currentLevel += 1;
        }




    }

    public void evolve(PlantParent to)
    {
        if (currentLevel >= 3) return;

        currentLevel += 1;
        print(transform.parent.name + "  " + to.AbilityName);

        pr.Add(to);
        GetComponent<PlantVisualManager>().UpdateSprites(currentLevel,"WIP", hp, pr);

        
    }

    public void Breed()
    {

        if (currentLevel == 2 && harvestedLevel == 3)
        {
            neighbours = GridSystem.instance.GetNeighbourPlants(GridSystem.instance.NameToVector(transform.parent.name), 2);
            neighbours.Remove(this.gameObject);

            if (neighbours.Count > 0)
            {
                neighbours[Random.Range(0, neighbours.Count)].GetComponent<plant>().evolve(pr[0]);

               


                harvest(false);
            }
        }


    }


    public void harvest(bool addToInv)
    {

        if (currentLevel > 1 && harvestedLevel >= 2)
        {
            GetComponent<PlantVisualManager>().UpdateSprites(currentLevel, "WIP", hp, pr, true);
            harvestedLevel = 0;

            if (addToInv)
            {
                foreach (var item in pr)
                {
                    inv.additem(item);
                }
            }
        }
    }

}

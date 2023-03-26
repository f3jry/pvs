using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public List<PlantParent> pr = new List<PlantParent>();
    public KytkaPopUp pop;

    public List<GameObject> neighbours;
    int maxHp = 6;
    int hp = 6;
    public float range = 1;
    public int currentLevel = 0;
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
        if(hp - damage <= maxHp)
        {
            hp -= damage;
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
        if (currentLevel >= 4) return;

        currentLevel += 1;
        print(transform.parent.name + "  " + to.AbilityName);

        pr.Add(to);
        GetComponent<PlantVisualManager>().UpdateSprites(currentLevel,"WIP", hp, pr);

        
    }

    public void Breed()
    {
        Debug.Log("tst");
        if (currentLevel == 2 && harvestedLevel == 3)
        {
            neighbours = GridSystem.instance.GetNeighbourPlants(GridSystem.instance.NameToVector(transform.parent.name), 2);
            neighbours.Remove(this.gameObject);

            List<GameObject> UsableNeighbour = new List<GameObject>();
            foreach (GameObject neighbour in neighbours)
            {
                if (neighbour.gameObject.GetComponent<plant>().currentLevel == 2 || neighbour.gameObject.GetComponent<plant>().currentLevel == 3)
                {
                    
                    UsableNeighbour.Add(neighbour);
                }
            }
            if(UsableNeighbour.Count>=1) { Debug.Log(UsableNeighbour.Count); }
            if (UsableNeighbour.Count > 0)
            {
                UsableNeighbour[Random.Range(0, neighbours.Count)].GetComponent<plant>().evolve(pr[0]);

               


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

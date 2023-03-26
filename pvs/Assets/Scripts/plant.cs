using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public List<PlantParent> pr = new List<PlantParent>();
    public KytkaPopUp pop;

    public SpriteRenderer ps;
    public SpriteRenderer plantsprite;
    KolaManager km;
    public int hp = 3;
    bool vyrostla = false;
    int growstage = 0;
    public Sprite growimage;
    public Sprite smallimage;


    public List<GameObject> neighbours;


    public float range = 1;
    int currentLevel = 0;
    PlantParent extparent;

    //3 not harvested, 2 NotHarvested+CannotBreed, 1 harvested waiting, 0 harvested
    public int harvestedLevel;

    GridSystem gs;
    gridcursor gc;
    inventory inv;
    int level = 0;
    public Color col;
    public GameObject hromada;
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
        ps.enabled = false;
        inv = FindObjectOfType<inventory>();
        
    }
    public void dosom()
    {
        if (pop != null) { pop.Pop(pr.Name, pr.AbilityDescription, pr.FruitSprite); }
    }
    private void OnMouseExit()
    {
        if (pop != null) { pop.kytka.SetActive(false); }
    }
    public void grow()
    {
        print("grow");
        
        if (growstage == 0) { plantsprite.sprite = smallimage; }
        if (growstage == 1) {plantsprite.sprite = growimage; }
        if (growstage == 2) {
            vyrostla = true;
            ps.enabled = true;
            evolve();

        }
        else
        {
            ps.enabled = false;
        }

        if (growstage < 2) { growstage += 1; }
        if(growstage == 2 && level == 0) {
            level = 1;
            }
        else if(growstage ==2 && level == 1)
        {
            if(GridSystem.instance.GetNeighbourPlants(gc.currentGridTile.transform.position, 1) != null)
            {
                level = 2;
                extparent = GridSystem.instance.GetNeighbourPlants(gc.currentGridTile.transform.position, 1)[0].GetComponentInChildren<plant>().pr;
            }
        }

        currentLevel = 0;
        GetComponent<PlantVisualManager>().UpdateSprites(currentLevel, "WIP", hp, pr);
    }
 
    public void takedamage(int damage)
    {
        hp -= damage;
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

    public void Takedamage(int amount)
    {

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
    private void Update()
    {
        if(hp <= 0){ GameObject d = Instantiate(hromada); d.transform.position = transform.position;Destroy(gameObject); }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{

    public PlantParent pr;
    public KytkaPopUp pop;
    public SpriteRenderer ps;
    public SpriteRenderer plantsprite;
    KolaManager km;
    int hp;
    bool vyrostla = false;
    int growstage = 0;
    public Sprite growimage;
    public Sprite smallimage;
    public float range = 1;
    GridSystem gs;
    gridcursor gc;
    // Update is called once per frame
    private void Start()
    {
        gs = FindObjectOfType<GridSystem>();
        growstage = 0;
        pop = FindObjectOfType<KytkaPopUp>();
        km = FindObjectOfType<KolaManager>();
        ps.sprite = pr.FruitSprite;
        PlantManager.instance.allPlants.Add(this);
        ps.enabled = false;
        
    }
    private void OnMouseEnter()
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
        if(growstage == 2) { print(gs.GetNeighbourPlants(gc.currentGridTile.transform.position,1)); }


    }
    public void takedamage(int damage)
    {
        hp -= damage;
    }
    public void evolve()
    {
        print("evolve  " + pr.AbilityName);
        GetComponent<PlantAbilities>().AddAbility(pr.AbilityName);
    }

}

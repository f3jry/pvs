using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public PlantParent pr;
    public KytkaPopUp pop;
    public SpriteRenderer ps;
    KolaManager km;
    int lastkolo;
    int hp;
    bool vyrostla = false;
    // Update is called once per frame
    private void Start()
    {
        pop = FindObjectOfType<KytkaPopUp>();
        km = FindObjectOfType<KolaManager>();
        ps.sprite = pr.FruitSprite;
    }
    private void OnMouseEnter()
    {
        if (pop != null) { pop.Pop(pr.Name, pr.AbilityDescription, pr.FruitSprite); }
    }
    private void OnMouseExit()
    {
        if (pop != null) { pop.kytka.SetActive(false); }
    }
    private void Update()
    {
        if (lastkolo != km.kolo)
        {
            vyrostla = true;
        }

        lastkolo = km.kolo;
    }
}

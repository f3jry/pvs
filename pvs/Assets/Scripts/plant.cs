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
    int lastkolo;
    int hp;
    bool vyrostla = false;
    int growstage = 0;
    public Sprite growimage;
    public Sprite smallimage;
    // Update is called once per frame
    private void Start()
    {
        
        growstage = 0;
        pop = FindObjectOfType<KytkaPopUp>();
        km = FindObjectOfType<KolaManager>();
        ps.sprite = pr.FruitSprite;
        ps.enabled = false;
        lastkolo = km.kolo;
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
            if (growstage == 1)
            {
                vyrostla = true;
                ps.enabled = true;
            }
            else
            {
                plantsprite.sprite = growimage;
            }

            growstage += 1;
        }
        if(growstage == 0) { plantsprite.sprite = smallimage; }
        lastkolo = km.kolo;
    }
}

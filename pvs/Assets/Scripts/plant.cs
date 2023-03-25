using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public PlantParent pr;
    public KytkaPopUp pop;
    public SpriteRenderer ps;
    // Update is called once per frame
    private void Start()
    {
        pop = FindObjectOfType<KytkaPopUp>();
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
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridcursor : MonoBehaviour
{
    Vector2 lastpos;
    public GameObject currentGridTile;
    public KytkaPopUp pop;

    void Update()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int posint = Vector3Int.FloorToInt(new Vector2(pos.x, pos.y));
        transform.position = Vector3.Lerp(transform.position,posint,0.2f);


        if (Physics2D.OverlapCircle(transform.position + new Vector3(.5f, .5f), 0.4f))
        {
            currentGridTile = Physics2D.OverlapCircle(transform.position + new Vector3(.5f,.5f), 0.4f).gameObject;
        }
        if(Input.GetMouseButton(1))
        {
            currentGridTile?.GetComponentInChildren<plant>()?.harvest(true);
        }

        /*
        PlantParent f = currentGridTile.GetComponentInChildren<plant>().pr;

        print(f);
        pop.Pop(f.Name, f.AbilityDescription, f.FruitSprite);*/
        //currentGridTile.GetComponentInChildren<plant>().dosom();
    }


    
}

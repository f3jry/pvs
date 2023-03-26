using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilliPepper : AbilityBase
{
    private void Awake()
    {
        abilityName = "Damage";
        thisPlant = GetComponent<plant>();

    }


    public override void CallAbility(bool start)
    {
        base.CallAbility(start);
        if (OnlyOnStart != start) return;
        //print("pos se rovnz  " + GridSystem.instance.NamePosToVector(transform.parent.name).x + " I " + GridSystem.instance.NamePosToVector(transform.parent.name).y);

        List<GameObject> neighbours = GridSystem.instance.GetNeighbourPlants(GridSystem.instance.NamePosToVector(transform.parent.name) , Mathf.RoundToInt(thisPlant.range + 1));

        foreach (GameObject item in neighbours)
        {
            item.GetComponent<plant>().takedamage(1);

            //print("neighbour " + item.name);
        }
    }
}

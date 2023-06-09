using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : AbilityBase
{

    private void Awake()
    {
        abilityName = "+HP";
        thisPlant = GetComponent<plant>();

    }

    public override void CallAbility(bool start)
    {
        List<GameObject> neighbours = GridSystem.instance.GetNeighbourPlants(transform.parent.position, Mathf.RoundToInt(thisPlant.range));

        foreach (GameObject item in neighbours)
        {
            item.GetComponent<plant>().takedamage(-1);

        }

    }
}

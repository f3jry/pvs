using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jablko : AbilityBase
{

    private void Awake()
    {
        abilityName = "Heal";
        thisPlant = GetComponent<plant>();

    }

    public override void CallAbility(bool start)
    {
        List<GameObject> neighbours = GridSystem.instance.GetNeighbourPlants(transform.parent.position, Mathf.RoundToInt(thisPlant.range));

        foreach (GameObject item in neighbours)
        {
            //item.GetComponent<plant>().takedamage(-);
            //Heal will be here
        }

    }
}

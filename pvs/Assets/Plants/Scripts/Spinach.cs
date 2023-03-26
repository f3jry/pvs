using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinach : AbilityBase
{

    private void Awake()
    {
        abilityName = "DoubleEffects";
        thisPlant = GetComponent<plant>();

    }

    public override void CallAbility(bool start)
    {
        List<GameObject> neighbours = GridSystem.instance.GetNeighbourPlants(transform.parent.position, Mathf.RoundToInt(thisPlant.range));

        foreach (GameObject item in neighbours)
        {
            //item.GetComponent<plant>().takedamage(-);
            //Heal will be here
            item.GetComponent<PlantAbilities>().AbilityEffectMultiplier += 1;

        }

    }
}

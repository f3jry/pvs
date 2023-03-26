using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : AbilityBase
{
    private void Awake()
    {
        abilityName = "SharpShooter";
        thisPlant = GetComponent<plant>();

    }


    public override void CallAbility(bool start)
    {
        List<GameObject> neighbours = GridSystem.instance.GetNeighbourPlants(transform.parent.position, Mathf.RoundToInt(thisPlant.range));
        GameObject Rneighbour = GridSystem.instance.GetNeighbourPlants(transform.parent.position, Mathf.RoundToInt(thisPlant.range))[Random.Range(0, neighbours.Count)];

        Rneighbour.GetComponent<plant>().takedamage(4);

    }
}

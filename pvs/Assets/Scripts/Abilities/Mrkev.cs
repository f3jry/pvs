using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mrkev : AbilityBase
{

    private void Awake()
    {
        abilityName = "+Range";
        thisPlant = GetComponent<plant>();

    }

    public override void CallAbility(bool start)
    {
        base.CallAbility(start);
        if (OnlyOnStart != start) return;


        thisPlant.range += 1;

    }
}

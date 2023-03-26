using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    [HideInInspector] public plant thisPlant;

    [HideInInspector] public string abilityName;
    public bool OnlyOnStart;
    int range;



    public virtual void CallAbility(bool start)
    {
        if (OnlyOnStart != start) return;

    }


}

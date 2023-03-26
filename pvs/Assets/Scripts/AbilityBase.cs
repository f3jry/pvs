using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    public plant thisPlant;

    public string abilityName;
    public bool OnlyOnStart;
    int range;



    public virtual void CallAbility(bool start)
    {
        if (OnlyOnStart != start) return;

        print(GetComponent<plant>().pr.AbilityName + " ability was called");


    }


}

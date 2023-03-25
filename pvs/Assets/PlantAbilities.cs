using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAbilities : MonoBehaviour
{
    //assign from plant script
    public string[] abilityName;

    public AbilityBase[] currentAbilities;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Call every round - stage 2
    public void WorldClock()
    {
        CallEffect();
    }

    public void CallEffect()
    {
        foreach (AbilityBase item in currentAbilities)
        {
            item.CallAbility();
        }
    }

    public void ListenToEffect()
    {

    }
}

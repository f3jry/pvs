using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAbilities : MonoBehaviour
{


    public List<AbilityBase> currentAbilities = new List<AbilityBase>();

    public int AbilityEffectMultiplier = 1;


    // Start is called before the first frame update
    void Start()
    {


        foreach (AbilityBase item in currentAbilities)
        {
            item.CallAbility(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddAbility("Damage");
        }

        currentAbilities = new List<AbilityBase>();
        foreach (var item in GetComponent<plant>().pr)
        {
            AddAbility(item.AbilityName);
        }
    }

    //assign from plant script
    public void AddAbility(string name)
    {
        foreach (AbilityBase item in GetComponents<AbilityBase>())
        {
            if(item.abilityName == name)
            {

                currentAbilities.Add(item);
            }
        }
    }

    //Call every round - stage 2
    public void CallEffects()
    {
        foreach (AbilityBase item in currentAbilities)
        {
            for (int i = 0; i < AbilityEffectMultiplier; i++)
            {
                item.CallAbility(false);
            }
        }
    }

    public void ListenToEffect()
    {

    }
}

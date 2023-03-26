using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName = "Plant")]
public class PlantParent : ScriptableObject
{
    public Sprite FruitSprite_LVL1_1,
                    FruitSprite_LVL_2_1,
                        FruitSprite_LVL_2_2,
                             FruitSprite_LVL_3_1,
                                FruitSprite_LVL_3_2,
                                    FruitSprite_LVL_3_3;
    public string Name;
    public string AbilityDescription;
    public string AbilityName;
    public int PriceSell;
    public int PriceBuy;
}
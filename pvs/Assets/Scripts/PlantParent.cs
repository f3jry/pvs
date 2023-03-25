using UnityEngine;

[CreateAssetMenu(fileName ="New Plant", menuName = "Plant")]
public class PlantParent : ScriptableObject
{
    public Sprite FruitSprite;
    public string Name;
    public string AbilityDescription;
    public string AbilityName;
    public int PriceSell;
    public int PriceBuy;
}
using UnityEngine;

[CreateAssetMenu(fileName = "New Pest", menuName = "Pest")]
public class PestParent : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public string AbilityDescription;
    public AbilityBase BaseAbility;
    public int Damage;
    public int HP;
    //public int SpawnRate;
}

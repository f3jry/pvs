using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class shopmanager : MonoBehaviour
{
    public inventory inv;
    public GameObject shop;
    public int money;
    public TMP_Text moneytext;
    public void randomflower(){ if (money > 1) { inv.additemrandom(); money -= 1; } }
    public void sellflower() { if (inv.selected.pr != null) { inv.deleteactive(); money += 1; } }
    public void toggleshop(bool s)
    {
        shop.SetActive(s);
    }
    public void Update()
    {
        moneytext.text = "money: " + money.ToString(); 
    }
}

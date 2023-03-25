using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KytkaPopUp : MonoBehaviour
{
    public GameObject kytka;
    public TMP_Text typkytkytext;
    public TMP_Text popiskytkytext;
    public Image obrazekkytkyimage;
    public void Pop(string typkytky, string popiskytky, Sprite obrazekkytky)
    {
        kytka.SetActive(true);
        typkytkytext.text = typkytky;
        popiskytkytext.text = popiskytky;
        obrazekkytkyimage.sprite = obrazekkytky;
    }

}

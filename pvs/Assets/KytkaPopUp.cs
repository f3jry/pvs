using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KytkaPopUp : MonoBehaviour
{
    public GameObject kytka;
    public Text typkytkytext;
    public Text popiskytkytext;
    public Image obrazekkytkyimage;
    public void Pop(string typkytky, string popiskytky, Texture2D obrazekkytky)
    {
        kytka.SetActive(true)
        typkytkytext.text = typkytky;
        popiskytkytext.text = popiskytky;
        obrazekkytkyimage.mainTexture = obrazekkytky;
    }

}

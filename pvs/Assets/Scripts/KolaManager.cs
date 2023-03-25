using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolaManager : MonoBehaviour
{
    public int kolo; // aktualni kolo

    public void dalsikolo() // pridej jedno kolo
    {
        kolo += 1;
        print(kolo);
    }
    private void Start()
    {
        kolo = 0;
    }
}

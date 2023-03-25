using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinSpawn : MonoBehaviour
{
    void spawnskutc()
    {
        float perlin = Mathf.PerlinNoise(1, Time.time);
        if (perlin > 0.5)
        {
            //spawnskutc(amount = perlin * 100)
        }
    }
}

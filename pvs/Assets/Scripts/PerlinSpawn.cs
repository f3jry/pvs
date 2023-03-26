using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinSpawn : MonoBehaviour
{
    public PestParent[] pestTypes;
    public static PerlinSpawn instance;
    int Level = 1;
    KolaManager kolaManager;

    Dictionary<string, int> values = new Dictionary<string, int>();

    private void Start()
    {
        kolaManager = GameObject.Find("Kolamanager").GetComponent<KolaManager>();
    }
    public Dictionary<string, int> Spawn()
    {
        //float x = Mathf.Lerp(0.5f,1.5f, Random.Range(0,1));
        //float y = Mathf.Lerp(0.5f, 1.5f, Random.Range(0, 1));
        float random = Random.Range(0.5f, 1.5f);
       // float perlin = Mathf.PerlinNoise(x, y);

        float spawnAphid = 0;
        float spawnCaterpillar = 0;
        float spawnSnail = 0;

        Level = kolaManager.kolo;

        //values = new Dictionary<string, int>();
        values.Clear();

        foreach (PestParent pest in pestTypes)
        {
            if (pest.Name == "Aphid")
            {
                spawnAphid = random * Level / 2 - 2;
                string Key = pest.Name;
                if(spawnAphid > 0)
                {
                    int spawnFinalA = Mathf.FloorToInt(spawnAphid);
                    values.Add(Key, spawnFinalA);
                }
            }
            
            else if (pest.Name == "Caterpillar")
            {
                spawnCaterpillar = random * Level / 5 - 0.5f;
                string Key = pest.Name;
                if (spawnCaterpillar > 0)
                {
                    int spawnFinalC = Mathf.FloorToInt(spawnCaterpillar);
                    values.Add(Key, spawnFinalC);
                }
            }

            else if (pest.Name == "Snail")
            {
                spawnSnail = random * Level / 10;
                string Key = pest.Name;
                if (spawnSnail > 0)
                {
                    int spawnFinalS = Mathf.FloorToInt(spawnSnail);
                    values.Add(Key, spawnFinalS);
                } 
            }
        }

        string valueString = "";
        foreach (KeyValuePair<string, int> pair in values)
        {
            valueString += pair.ToString();
        }
        print(valueString);
        return values;
        
    }
    /*void spawnskutc()
    {
        float perlin = Mathf.PerlinNoise(1, Time.time);
        if (perlin > 0.5)
        {
            //spawnskutc(amount = perlin * 100)
        }
    }*/
}

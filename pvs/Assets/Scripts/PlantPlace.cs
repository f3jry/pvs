using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlace : MonoBehaviour
{
    public gridcursor cursor;

    public GameObject plant;
    public PlantParent pr1;
    public inventory inv;
    public List<Vector2> ocupiedtiles;
    //public GameObject[] plants;
    
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inv.selected.pr != null)
        {
            Placeplant(inv.selected.pr);
            
        }
    }
    public void Placeplant(PlantParent pr)
    {


        if (cursor?.currentGridTile?.transform.childCount < 2)
        {
            GameObject insPlant = Instantiate(plant, cursor.currentGridTile.transform);
            insPlant.GetComponent<plant>().pr = pr;
            inv.deleteactive();

        }



    }
}

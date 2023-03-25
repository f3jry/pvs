using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlace : MonoBehaviour
{
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
        if (Input.GetMouseButtonDown(0))
        {
            Placeplant(inv.selectedparent);
        }
    }
    public void Placeplant(PlantParent pr)
    {
        Vector3 pos = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + new Vector3(0.5f, 0.5f, 10);
        Vector2 pos2 = new Vector2(pos.x, pos.y);
        if (!ocupiedtiles.Contains(pos2))
        {
            GameObject insplant = Instantiate(plant);
            insplant.GetComponent<plant>().pr = pr;
            insplant.transform.position = pos;
            ocupiedtiles.Add(insplant.transform.position);
        }
    }
}

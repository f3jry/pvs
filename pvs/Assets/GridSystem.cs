using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static GridSystem instance;
    public GameObject GridTile;

    public Vector2Int gridsize;
    public float tileOffset;
    // ahoj

    //[HideInInspector]
    public Transform[] GridTiles;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        CreateGrid(gridsize);
        centerGrid();
    }

    // Update is called once per frame
    void Update()
    {
        GridTiles = new Transform[transform.GetChild(0).childCount];

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            GridTiles[i] = transform.GetChild(0).GetChild(i);
        }
    }




    public void CreateGrid(Vector2 size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                GameObject tile = Instantiate(GridTile, transform.GetChild(0).transform);
                tile.transform.position = new Vector3(x + (x * tileOffset), y + (y * tileOffset), 0);

                tile.name = "" + x + " " + y;
                /*
                float r = Random.value * 10;
                Color col = tile.GetComponentInChildren<SpriteRenderer>().color;
                tile.GetComponentInChildren<SpriteRenderer>().color = new Color(col.r + r, col.g + r, col.b +r, 255);*/
            }
        }
    }


    public void centerGrid()
    {
        transform.position = new Vector2(-gridsize.x / 2f, -gridsize.y / 2f);


    }

    public void PlacePlant(Vector2 pos, /*temp replace with flower class*/ GameObject PlantObject)
    {
        GameObject plant = Instantiate(PlantObject, GetTile(pos).transform);
        plant.transform.localPosition = new Vector3(0, 0, 0);
        
    }


    /*
    public void PlacePlantToPointer(GameObject PlantObject)
    {



        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        GameObject plant = Instantiate(PlantObject, GetTile(PlacePos).transform);

        print(Mathf.Round(mousePos.x) + "  " + Mathf.Round(mousePos.y));

        plant.transform.localPosition = new Vector3(0, 0, 0);

    }*/

    public bool IsPlantAt(Vector2 pos)
    {
        Transform tileT = GetTile(pos).transform;

        if (tileT.transform.childCount > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void RemovePlant(Vector2 pos)
    {
        Transform tileT = GetTile(pos).transform;

        if (tileT.transform.childCount > 1)
        {
            Destroy(tileT.GetChild(1).gameObject);
        }


    }
    
    public List<GameObject> GetNeighbourPlants(Vector2 pos, int size)
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(new Vector2(pos.x + (pos.x * tileOffset) - gridsize.x / 2f, pos.y + (pos.y * tileOffset) - gridsize.y / 2f), new Vector2(size, size), 0);
        List<GameObject> result = new List<GameObject>();

        for (int i = 0; i < col.Length; i++)
        {
            //result.Add(col[i].gameObject);


            
            if (col[i].transform.childCount > 1)
            {

                result.Add(col[i].transform.GetChild(1).gameObject);

            }
        }

        return result;
    }

    public GameObject GetPlant(Vector2 pos)
    {
        return GetTile(pos).transform.GetChild(1).gameObject;
    }

    public GameObject GetTile(Vector2 pos)
    {

        foreach (Transform item in GridTiles)
        {
            int sx = int.Parse(item.name.Split(' ')[0]);
            int sy = int.Parse(item.name.Split(' ')[1]);

            if (sx == pos.x && sy == pos.y)
            {
                GameObject tile;

                tile = item.gameObject;



                return tile;
            }
            //print(pos.x + " ,  " + pos.y + "   " + (item.position.x) + "  ,   "+ (item.position.y));


        }

        Debug.LogError("No Tile found at:  " + pos.x + ", " + pos.y);

        return null;

    }

    public Vector2 NamePosToVector(string name)
    {
        int sx = int.Parse(name.Split(' ')[0]);
        int sy = int.Parse(name.Split(' ')[1]);

        return new Vector2(sx, sy);
    }
}

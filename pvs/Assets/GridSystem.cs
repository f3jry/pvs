using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject GridTile;

    public Vector2Int gridsize;
    public float tileOffset;

    //[HideInInspector]
    public Transform[] GridTiles;
    // Start is called before the first frame update
    void Awake()
    {
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

    public void PlaceFlower(Vector2Int pos, /*temp replace with flower class*/ GameObject flowerObject)
    {
        Transform parentTile = null;

        foreach (Transform item in GridTiles)
        {
            if (item.localPosition.x + tileOffset == pos.x && item.localPosition.y + tileOffset == pos.y)
            {

                parentTile = item;
                print(parentTile.gameObject.name);

                return;
            }
        }

        Debug.LogError("No Tile found at:  " + pos.x + ", " pos.y);


    }
}

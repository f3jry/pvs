using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKytkaPlacer : MonoBehaviour
{
    public GridSystem gridSystem;
    public GameObject tempKytkaObject;

    public Vector2Int pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
          gridSystem.PlaceFlower(pos, tempKytkaObject);

        }
    }
}

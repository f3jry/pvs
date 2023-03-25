using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridcursor : MonoBehaviour
{
    Vector2 lastpos;
    void Update()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int posint = Vector3Int.FloorToInt(new Vector2(pos.x, pos.y));
        transform.position = Vector3.Lerp(transform.position,posint,0.2f);

    }
}

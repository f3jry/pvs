using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 firstmouseposition;
    public Transform tra;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) 
        {
            
            if (firstmouseposition == Vector3.zero) firstmouseposition = Input.mousePosition;
            Vector3 d = Vector3.zero;
            d += (firstmouseposition - Input.mousePosition) / 1000;
            print(firstmouseposition);
            tra.position = Vector3.Lerp(transform.position, transform.position + d, 10);
        }
        if (Input.GetMouseButtonUp(1)) firstmouseposition = Vector3.zero;
        Camera cam = GetComponent<Camera>();
        GetComponent<Camera>().orthographicSize += Input.mouseScrollDelta.y * -5;
        if (GetComponent<Camera>().orthographicSize < 5) cam.orthographicSize = 5;
        else if (cam.orthographicSize > 30) cam.orthographicSize = 30;
    }
}

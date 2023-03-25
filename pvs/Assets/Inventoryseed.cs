using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventoryseed : MonoBehaviour
{
    public Image seedimage;
    public PlantParent pr;
    public TMP_Text infotext;
    bool ismouse = false;
    public Image img;
    float offset = 70;
    private void OnMouseEnter()
    {
        ismouse = true;
        
    }
    private void OnMouseExit()
    {
        ismouse = false;
    }
    private void Update()
    {
        if (ismouse)
        {
            img.transform.position = Vector2.Lerp(img.transform.position, new Vector2(0, 70), 1);
        }
        else
        {
            img.transform.position = Vector2.Lerp(img.transform.position, new Vector2(0, 0), 1);
        }
    }
}

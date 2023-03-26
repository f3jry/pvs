using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour
{
    public GameObject plantprefab;
    public List<GameObject> inv;
    public PlantParent pr1;
    public PlantParent pr2;
    public Transform spawnobject;
    public GameObject selected;
    int selectedplant = 0;
    public PlantParent selectedparent;
    public void additem(PlantParent pr)
    {
        GameObject seeditem = Instantiate(plantprefab);
        seeditem.transform.parent = spawnobject;
        Inventoryseed invseed = seeditem.GetComponent<Inventoryseed>();
        invseed.seedimage.sprite = pr.FruitSprite;
        invseed.pr = pr;
        inv.Add(invseed.gameObject);
        invseed.infotext.text = pr.Name;
    }
    private void Start()
    {
        additem(pr1);
        additem(pr2);
        additem(pr1);
        additem(pr2);
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0) { selectedplant += 1; }
        if (Input.mouseScrollDelta.y < 0) { selectedplant -= 1; }
        if (selectedplant < 0) selectedplant = 0;
        if (selectedplant > inv.Count -1) selectedplant = inv.Count - 1;
        print(selectedplant);
        if (inv.Count > 0)
        {

            selected = inv[(int)selectedplant];
            foreach (GameObject item in inv)
            {
                item.GetComponent<Image>().color = Color.black;
            }
            selected.GetComponent<Image>().color = Color.red;
            selectedparent = selected.GetComponent<Inventoryseed>().pr;

        }

    }
    public void deleteactive()
    {
        Destroy(inv.ToArray()[selectedplant].gameObject);
        inv.RemoveAt(selectedplant);
        selectedparent = null;
    }
}


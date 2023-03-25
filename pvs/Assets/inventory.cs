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
    void additem(PlantParent pr)
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
        if (Input.GetKeyDown("1")) { selectedplant = 0; }
        if (Input.GetKeyDown("2")) { selectedplant = 1; }
        if (Input.GetKeyDown("3")) { selectedplant = 2; }
        if (Input.GetKeyDown("4")) { selectedplant = 3; }
        if (Input.GetKeyDown("5")) { selectedplant = 4; }

        print(selectedplant);
        selected = inv[(int)selectedplant];
        foreach (GameObject item in inv)
        {
            item.GetComponent<Image>().color = Color.black;
        }
        selected.GetComponent<Image>().color = Color.red;
        selectedparent = selected.GetComponent<Inventoryseed>().pr;
    }
    public void deleteactive()
    {
        Destroy(inv.ToArray()[selectedplant].gameObject);
        inv.RemoveAt(selectedplant);
    }
}

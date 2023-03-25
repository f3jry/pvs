using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject plantprefab;
    public List<GameObject> inv;
    public PlantParent pr1;
    public PlantParent pr2;
    public Transform spawnobject;
    public PlantParent selected;
    float selectedplant;
    void additem(PlantParent pr)
    {
        GameObject seeditem = Instantiate(plantprefab);
        seeditem.transform.parent = spawnobject;
        Inventoryseed invseed = seeditem.GetComponent<Inventoryseed>();
        invseed.seedimage.sprite = pr.FruitSprite;
        invseed.pr = pr;
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
        selectedplant += Input.mouseScrollDelta.y * -1;
        print(selectedplant);
        selected = inv[(int)selectedplant];
        selected.
    }
}

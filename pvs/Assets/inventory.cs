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
    float selectedplant = 0;
    void additem(PlantParent pr)
    {
        GameObject seeditem = Instantiate(plantprefab);
        seeditem.transform.parent = spawnobject;
        Inventoryseed invseed = seeditem.GetComponent<Inventoryseed>();
        invseed.seedimage.sprite = pr.FruitSprite;
        invseed.pr = pr;
        inv.Add(invseed.gameObject);
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
        if ((int)selectedplant < inv.Count){ selectedplant = inv.Count - 1; }
        selected.GetComponent<Image>().color = Color.red;
    }
}

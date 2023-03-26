using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventory : MonoBehaviour
{
    public List<PlantParent> startitems;

    public GameObject plantprefab;
    public List<GameObject> inv;


    public Transform spawnobject;
    public Inventoryseed selected;
    int selectedplant = 0;

    public Animator vysunoutAnimator;

    public Color colorCardSelected, colorCardDefault;

    public PlantParent[] parents;
    public void additem(PlantParent pr)
    {
        GameObject seeditem = Instantiate(plantprefab);
        seeditem.transform.parent = spawnobject;
        Inventoryseed invseed = seeditem.GetComponent<Inventoryseed>();
        invseed.seedimage.sprite = pr.FruitSprite_LVL1_1;
        invseed.pr = pr;
        inv.Add(invseed.gameObject);
        invseed.infotext.text = pr.Name;
    }
    public void additemrandom()
    {
        additem(parents[Random.Range(0, 4)]);
    }
    private void Start()
    {
        foreach (var item in startitems)
        {
            additem(item);
        }
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y < 0) { selectedplant += 1; }
        if (Input.mouseScrollDelta.y > 0) { selectedplant -= 1; }
        if (selectedplant < 0) selectedplant = 0;
        if (selectedplant > inv.Count -1) selectedplant = inv.Count - 1;
        if (inv.Count > 0)
        {

            selected = inv[(int)selectedplant].GetComponent<Inventoryseed>();
            foreach (GameObject item in inv)
            {
                item.GetComponent<Inventoryseed>().background.color = colorCardDefault;
            }
            selected.background.color = colorCardSelected;


        }

        if(Camera.main.ScreenToViewportPoint(Input.mousePosition).y < .15f)
        {

            vysunoutAnimator.SetBool("Vysunout", true);
        }
        else
        {
            vysunoutAnimator.SetBool("Vysunout", false);

        }

    }


    private void OnMouseEnter()
    {
        print("entr");
    }
    public void deleteactive()
    {
        Destroy(inv.ToArray()[selectedplant].gameObject);
        inv.RemoveAt(selectedplant);
        selected.pr = null;
    }
    
}


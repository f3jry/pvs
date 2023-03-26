using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVisualManager : MonoBehaviour
{
    public Sprite StonekG_small, StonekY_small, StonekB_small;
    public Sprite StonekG_middle, StonekY_middle, StonekB_middle;
    public Sprite StonekG_big, StonekY_big, StonekB_big;
    public Sprite Snek_small, Snek_middle, Snek_big;
    public Sprite Housk_small, Housk_middle, Housk_big;
    public Sprite Aphid_small, Aphid_middle, Aphid_big;

    [Space(30)]
    public SpriteRenderer Stonek;
    public SpriteRenderer pestRenderer;
    public SpriteRenderer Plod1S, Plod2S, Plod3S;


    public void UpdateSprites(int level, string pest, int health, List<PlantParent> pr, bool harvested = false)
    {
        print(pest);
        if (level > 1)
        {
            if (level > 2)
            {
                if (level > 3)
                {
                    if (health >= 6)
                    {
                        Stonek.sprite = StonekG_big;

                    }
                    else if (health > 1)
                    {
                        Stonek.sprite = StonekY_big;
                    }
                    else
                    {
                        Stonek.sprite = StonekB_big;
                    }

                    if (!harvested)
                    {
                        Plod1S.sprite = pr[0].FruitSprite_LVL_3_1;
                        Plod2S.sprite = pr[1].FruitSprite_LVL_3_2;
                        Plod3S.sprite = pr[2].FruitSprite_LVL_3_3;
                    }
                    else
                    {
                        Plod1S.sprite = null;
                        Plod2S.sprite = null;
                        Plod3S.sprite = null;
                    }
                }
                else
                {
                    if (health >= 6)
                    {
                        Stonek.sprite = StonekG_middle;

                    }
                    else if (health > 1)
                    {
                        Stonek.sprite = StonekY_middle;
                    }
                    else
                    {
                        Stonek.sprite = StonekB_middle;
                    }

                    if (!harvested)
                    {
                        Plod1S.sprite = pr[0].FruitSprite_LVL_2_1;
                        Plod2S.sprite = pr[1].FruitSprite_LVL_2_2;
                    }
                    else
                    {
                        Plod1S.sprite = null;
                        Plod2S.sprite = null;
                    }


                    if (pest == "Aphid") { pestRenderer.sprite = Aphid_big; }
                    else if (pest == "Caterpillar") { pestRenderer.sprite = Housk_big; }
                    else if (pest == "Snail") { pestRenderer.sprite = Snek_big; }
                    else { pestRenderer.sprite = null; }

                }
            }
            else
            {
                Stonek.sprite = StonekG_small;

                if (!harvested)
                {
                    Plod1S.sprite = pr[0].FruitSprite_LVL1_1; ;
                }
                else
                {
                    Plod1S.sprite = null;
                }

                if (health >= 6)
                {
                    Stonek.sprite = StonekG_small;

                }
                else if (health > 1)
                {
                    Stonek.sprite = StonekY_small;
                }
                else
                {
                    Stonek.sprite = StonekB_small;
                }

                if (pest == "Aphid") { pestRenderer.sprite = Aphid_middle; }
                else if (pest == "Caterpillar") { pestRenderer.sprite = Housk_middle; }
                else if (pest == "Snail") { pestRenderer.sprite = Snek_middle; }
                else { pestRenderer.sprite = null; }

            }

        }
        else
        {
            if(health >= 6)
            {
                Stonek.sprite = StonekG_small;

            }else if(health > 1)
            {
                Stonek.sprite = StonekY_small;
            }
            else
            {
                Stonek.sprite = StonekB_small;
            }

            if (pest == "Aphid"){pestRenderer.sprite = Aphid_small;} 
            else if (pest == "Caterpillar"){pestRenderer.sprite = Housk_small;}
            else if (pest == "Snail") { pestRenderer.sprite = Snek_small;}
            else{ pestRenderer.sprite = null;}
        }


    }
}

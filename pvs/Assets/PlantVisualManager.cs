using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVisualManager : MonoBehaviour
{
    public Sprite StonekG_small, StonekY_small, StonekB_small;
    public Sprite StonekG_middle, StonekY_middle, StonekB_middle;
    public Sprite StonekG_big, StonekY_big, StonekB_big;

    [Space(30)]
    public SpriteRenderer Stonek;
    public SpriteRenderer infekce;
    public SpriteRenderer Plod1S, Plod2S, Plod3S;


    public void UpdateSprites(int level, string infekce, int health, List<PlantParent> pr, bool harvested = false)
    {
        if (level > 1)
        {
            if (level > 2)
            {
                if (level > 3)
                {
                    Stonek.sprite = StonekG_big;

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
                    Stonek.sprite = StonekG_middle;

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

            }

        }
        else
        {
            Stonek.sprite = StonekG_small;
        }
    }
}

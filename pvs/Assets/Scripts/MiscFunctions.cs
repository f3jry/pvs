using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscFunctions : MonoBehaviour
{
   public Button ButtonToDisable;
   public void DisableButton()
    {
        StartCoroutine(Disable());

        IEnumerator Disable()
        {
            ButtonToDisable.interactable = false;
            yield return new WaitForSeconds(1);
            ButtonToDisable.interactable = true;
        }
    }
}

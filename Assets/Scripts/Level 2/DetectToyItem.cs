using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DetectToyItem : MonoBehaviour
{
    public int itemNumber;

    public void PlaceItem()
    {
        int itemNumber = DialogueLua.GetVariable("2_5_Item").asInt;
        itemNumber++;
        DialogueLua.SetVariable("2_5_Item", itemNumber);
        Debug.Log(DialogueLua.GetVariable("2_5_Item").asInt);
    }

    public void RemoveItem()
    {
        int itemNumber = DialogueLua.GetVariable("2_5_Item").asInt;
        itemNumber--;
        DialogueLua.SetVariable("2_5_Item", itemNumber);
        Debug.Log(DialogueLua.GetVariable("2_5_Item").asInt);
    }

    private void Update()
    {
        int itemNumber = DialogueLua.GetVariable("2_5_Item").asInt;
        if (itemNumber == 7)
        {
            //do sth.
        }
    }
}

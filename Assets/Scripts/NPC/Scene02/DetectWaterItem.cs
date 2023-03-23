using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DetectWaterItem : MonoBehaviour
{
    public void WipeWater()
    {
        int itemNumber = DialogueLua.GetVariable("2_2_Water").asInt;
        itemNumber++;
        DialogueLua.SetVariable("2_2_Water", itemNumber);
        Debug.Log(DialogueLua.GetVariable("2_2_Water").asInt);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DetectTeacherItem : MonoBehaviour
{
    public void PlaceDustbin()
    {
        DialogueLua.SetVariable("2_1_Dustbin", true);
        Debug.Log(DialogueLua.GetVariable("2_1_Dustbin").asBool);
    }

    public void RemoveDustbin()
    {
        DialogueLua.SetVariable("2_1_Dustbin", false);
        Debug.Log(DialogueLua.GetVariable("2_1_Dustbin").asBool);
    }

    public void PlaceItem()
    {
        int itemNumber = DialogueLua.GetVariable("2_1_TeacherItem").asInt;
        itemNumber++;
        DialogueLua.SetVariable("2_1_TeacherItem", itemNumber);
        Debug.Log(DialogueLua.GetVariable("2_1_TeacherItem").asInt);
    }

    public void RemoveItem()
    {
        int itemNumber = DialogueLua.GetVariable("2_1_TeacherItem").asInt;
        itemNumber--;
        DialogueLua.SetVariable("2_1_TeacherItem", itemNumber);
        Debug.Log(DialogueLua.GetVariable("2_1_TeacherItem").asInt);
    }
}

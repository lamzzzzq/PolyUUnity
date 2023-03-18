using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GlassesDetectLogic : MonoBehaviour
{
    private bool isProcessing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isProcessing) return;

        if (other.CompareTag("Glasses_Real"))
        {
            isProcessing = true;
            RealGlasses();
        }
        else if (other.CompareTag("Glasses_Fake"))
        {
            isProcessing = true;
            FakeGlasses();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Glasses_Real") || other.CompareTag("Glasses_Fake"))
        {
            isProcessing = false;
        }
    }

    private void RealGlasses()
    {
        Debug.Log("RealGlasses entered the trigger.");
        QuestLog.SetQuestState("1.4_GrandmaGlasses", QuestState.Success);
        DialogueLua.SetVariable("1_4_Glasses", true);
        // Perform actions specific to the apple here
    }

    private void FakeGlasses()
    {
        Debug.Log("FakeGlasses entered the trigger.");
        // Perform actions specific to the pear here
        QuestLog.SetQuestState("1.4_GrandmaGlasses", QuestState.Success);
        DialogueLua.SetVariable("1_4_Glasses", false);
    }
}

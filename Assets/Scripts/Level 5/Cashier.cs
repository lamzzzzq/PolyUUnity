using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Cashier : MonoBehaviour
{

    public void CollectChangeLogicCashier()
    {
        //set quest status to abandoned
        QuestLog.SetQuestState("WatsonCheckOut", QuestState.Abandoned);
        //end conversation
        DialogueManager.StopConversation();
        //start new conversation
        StartCoroutine(Talk());
    }

    private IEnumerator Talk()
    {
        yield return new WaitForSeconds(1);

        foreach (var item in GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
            Debug.Log("Talk");
        }


    }

}

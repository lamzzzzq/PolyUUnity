using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class NPCTalkDialogue : MonoBehaviour
{
    public GameObject npc;
    public GameObject button;


    public void StartConversationWithNPC()
    {
        //PixelCrushers.QuestMachine.QuestGiver.Start

        foreach (var trigger in npc.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }

        button.SetActive(false);


    }
}
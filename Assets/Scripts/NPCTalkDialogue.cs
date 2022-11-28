using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class NPCTalkDialogue : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject button;


    public void StartConversationWithNPC()
    {
        //PixelCrushers.QuestMachine.QuestGiver.Start

        gameObject.GetComponent<DialogueSystemTrigger>().OnUse();

        button.SetActive(false);


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class NPCTalk : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject button;
    

    public void StartConversationWithNPC()
    {
        //PixelCrushers.QuestMachine.QuestGiver.Start

        gameObject.GetComponent<PixelCrushers.QuestMachine.QuestGiver>().StartDialogueWithPlayer();   //为什么这么写？

        button.SetActive(false);


    }








}

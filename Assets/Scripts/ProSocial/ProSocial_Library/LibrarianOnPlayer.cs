using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LibrarianOnPlayer : MonoBehaviour
{
    public GameObject npc;
    public GameObject phone;
    public GameObject phoneRing;

    public void PhoneDisappearAndTalk()
    {
        //Phone Disappear
        phone.SetActive(false);
        //Disable trigger
        phoneRing.SetActive(false);
        //Player Talk
        QuestLog.SetQuestState("Library_TASK_1", QuestState.Abandoned);

        foreach (var item in npc.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }
}

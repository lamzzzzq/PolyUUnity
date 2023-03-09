using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

namespace BNG
{
    public class DetectGift : MonoBehaviour
    {
        public RandomWordGenerator gift;
        public SnapZone snapZone;
        public GameObject snapZoneGameObj;
        public GameObject guideCanvas;

        public bool isDecided;
        public GameObject cashier;

        public void TriggerCashierConversation()
        {
            //QuestLog.SetQuestState("WatsonCheckOut", QuestState.Active);
            guideCanvas.SetActive(true);
            cashier.GetComponent<DialogueSystemTrigger>().OnUse();
        }


        public void DetectItem()
        {
            if (snapZone.HeldItem.CompareTag(gift.randomWord))
            {
                int oldValue = DialogueLua.GetVariable("Point_Level5").asInt;
                int newValue = oldValue + 20;
                DialogueLua.SetVariable("Point_Level5", newValue);
                snapZoneGameObj.SetActive(false);
                guideCanvas.SetActive(false);
            }
        }
    }
}
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

        TeleportPlayerFade fade;

        public void TriggerCashierConversation()
        {
            //QuestLog.SetQuestState("WatsonCheckOut", QuestState.Active);

            //need to end a current conversation here

            guideCanvas.SetActive(true);
            foreach (var trigger in cashier.GetComponents<DialogueSystemTrigger>())
            {
                trigger.OnUse();
            }
        }


        public void DetectItem()
        {
            if (snapZone.HeldItem.CompareTag(gift.randomWord))
            {
                //fade.FadeCutscene();
                int oldValue = DialogueLua.GetVariable("Point_Level5").asInt;
                int newValue = oldValue + 20;
                DialogueLua.SetVariable("Point_Level5", newValue);
                guideCanvas.SetActive(false);
                snapZoneGameObj.SetActive(false);


            }
            else
            {
                //fade.FadeCutscene();
                guideCanvas.SetActive(false);
                snapZoneGameObj.SetActive(false);


            }
        }
    }
}
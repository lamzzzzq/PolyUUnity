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
            Debug.Log("snapZone.HeldItem.tag:" + snapZone.HeldItem.tag);
            Debug.Log("gift.randomWordForCheck:" + gift.randomWord);

            if (snapZone.HeldItem != null && !string.IsNullOrEmpty(snapZone.HeldItem.tag))
            {
                if (snapZone.HeldItem.tag == gift.randomWord)
                {
                    //fade.FadeCutscene();
                    Debug.Log("Yes");
                    int oldValue = DialogueLua.GetVariable("Point/Level_5").asInt;
                    int newValue = oldValue + 20;
                    DialogueLua.SetVariable("Point/Level_5", newValue);
                    guideCanvas.SetActive(false);
                    snapZoneGameObj.SetActive(false);


                }
                else
                {
                    //fade.FadeCutscene();
                    Debug.Log("No");
                    guideCanvas.SetActive(false);
                    snapZoneGameObj.SetActive(false);
                }
            }
            else
            {
                Debug.LogWarning("SnapZoneObj的HeldItem的标签为空");
            }
        }
    }
}
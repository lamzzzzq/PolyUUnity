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

        public bool isDecided;
        public GameObject cashier;

        // Start is called before the first frame update
/*        private void OnTriggerStay(Collider other)
        {
            if (!isPlaced)
            {
                QuestLog.SetQuestState("WatsonCheckOut", QuestState.Active);
                isPlaced = true;
                cashier.GetComponent<DialogueSystemTrigger>().OnUse();
                if (other.gameObject.CompareTag(gift.randomWord))
                {
                    int oldValue = DialogueLua.GetVariable("Point_Level5").asInt;
                    if (!isDecided)
                    {
                        int newValue = oldValue + 20;
                        DialogueLua.SetVariable("Point_Level5", newValue);
                        isDecided = true;
                    }
                    //QuestLog.SetQuestState
                }
            }
        }*/

/*        private void OnTriggerExit(Collider other)
        {
            isPlaced = false;
        }*/

        public void TriggerCashierConversation()
        {
            //QuestLog.SetQuestState("WatsonCheckOut", QuestState.Active);
            cashier.GetComponent<DialogueSystemTrigger>().OnUse();
            Debug.Log("kk");
        }


        public void DetectItem()
        {
            if (snapZone.HeldItem.CompareTag(gift.randomWord))
            {
                Debug.Log("match");
                int oldValue = DialogueLua.GetVariable("Point_Level5").asInt;
                int newValue = oldValue + 20;
                DialogueLua.SetVariable("Point_Level5", newValue);
            }
            else
            {
                Debug.Log("not match");
            }
        }
    }
}
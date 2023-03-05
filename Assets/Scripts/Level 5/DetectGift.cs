using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class DetectGift : MonoBehaviour
{
    public RandomWordGenerator gift;

    public bool isPlaced;
    public bool isDecided;
    public GameObject cashier;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(!isPlaced)
        {
            QuestLog.SetQuestState("WatsonCheckOut",QuestState.Active);
            Debug.Log("1111");
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
    }

    private void OnTriggerExit(Collider other)
    {
        isPlaced = false;
    }
}

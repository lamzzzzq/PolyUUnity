using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestComplete : MonoBehaviour
{
    //public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
/*        // Find the menuContainer GameObject (if it exists in the scene)
        GameObject menuContainerObject = GameObject.FindGameObjectWithTag("WristMenu");

        // Assign the menuContainer variable if the GameObject is found
        if (menuContainerObject != null)
        {
            menu = menuContainerObject;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("1_1_CleanTheDirt: " + QuestLog.CurrentQuestState("1_1_CleanTheDirt"));
        Debug.Log("1_2_Sandwich: " + QuestLog.CurrentQuestState("1_2_Sandwich"));
        Debug.Log("1_3_WashPlate: " + QuestLog.CurrentQuestState("1_3_WashPlate"));
        Debug.Log("1_4_GrandmaGlasses: " + QuestLog.CurrentQuestState("1_4_GrandmaGlasses"));
        Debug.Log("1_5_Sister: " + QuestLog.CurrentQuestState("1_5_Sister"));

        if ((QuestLog.CurrentQuestState("1_1_CleanTheDirt") == "abandoned") && (QuestLog.CurrentQuestState("1_2_Sandwich") == "abandoned") && (QuestLog.CurrentQuestState("1_3_WashPlate") == "abandoned") && (QuestLog.CurrentQuestState("1_4_GrandmaGlasses") == "abandoned") && (QuestLog.CurrentQuestState("1_5_Sister") == "success"))
        {
            Debug.Log("Level Complete!");
            //menu.SetActive(true);
        }
        else
        {
            Debug.Log("If statement not met");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestComplete : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        // Find the menuContainer GameObject (if it exists in the scene)
        GameObject menuContainerObject = GameObject.FindGameObjectWithTag("WristMenu");

        // Assign the menuContainer variable if the GameObject is found
        if (menuContainerObject != null)
        {
            menu = menuContainerObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(((QuestLog.CurrentQuestState("1_1_CleanTheDirt") == "Abandoned")&& (QuestLog.CurrentQuestState("1_2_Sandwich") == "Abandoned") && (QuestLog.CurrentQuestState("1_3_WashPlate") == "Abandoned") && (QuestLog.CurrentQuestState("1.4_GrandmaGlasses") == "Abandoned") && (QuestLog.CurrentQuestState("1.5_Sister") == "Success")) || ((QuestLog.CurrentQuestState("2.1_TeacherDropItem") == "Abandoned") && (QuestLog.CurrentQuestState("2.2_WaterPour") == "Abandoned") && (QuestLog.CurrentQuestState("2.3_FindPen") == "success") && (QuestLog.CurrentQuestState("2.4_ComfortClassmate") == "success") && (QuestLog.CurrentQuestState("2.5_Organize") == "Abandoned")))
        {
            menu.SetActive(true);
        }
    }
}

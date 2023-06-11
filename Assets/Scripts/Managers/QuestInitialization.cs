using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestInitialization : MonoBehaviour
{
/*    [System.Serializable]
    public struct QuestStatus
    {
        public string questName;
        public QuestState questState;
    }

    public List<QuestStatus> initialQuestStatuses;*/

    void Start()
    {
        DialogueManager.StopConversation();
        ResetQuests();
        ResetPoint();
    }

    void ResetQuests()
    {

        //Level 1
        QuestLog.SetQuestState("1_1_CleanTheDirt", QuestState.Unassigned);
        QuestLog.SetQuestState("1_2_Sandwich", QuestState.Unassigned);
        QuestLog.SetQuestState("1_3_WashPlate", QuestState.Unassigned);
        QuestLog.SetQuestState("1.4_GrandmaGlasses", QuestState.Unassigned);
        QuestLog.SetQuestState("1.5_Sister", QuestState.Unassigned);

        //Level 2
        QuestLog.SetQuestState("2.1_TeacherDropItem", QuestState.Unassigned);
        QuestLog.SetQuestState("2.2_WaterPour", QuestState.Unassigned);
        QuestLog.SetQuestState("2.3_FindPen", QuestState.Unassigned);
        QuestLog.SetQuestState("2.4_ComfortClassmate", QuestState.Unassigned);
        QuestLog.SetQuestState("2.5_Organize", QuestState.Unassigned);

        //Level 3


        /*        foreach (QuestStatus qs in initialQuestStatuses)
                {
                    QuestLog.SetQuestState(qs.questName, qs.questState);


                }*/
    }

    void ResetPoint()
    {
        DialogueLua.SetVariable("Point_Level", 0);
        DialogueLua.SetVariable("Point_Level2", 0);
        DialogueLua.SetVariable("1_1_Dirt", 0);
        DialogueLua.SetVariable("1_2_SandWich", 0);
        DialogueLua.SetVariable("1_3_Dirt", 0);
        DialogueLua.SetVariable("1_4_Glasses", false);
        DialogueLua.SetVariable("2_1_TeacherItem", 0);
        DialogueLua.SetVariable("2_1_Dustbin", false);
        DialogueLua.SetVariable("2_2_Water", 0);
        DialogueLua.SetVariable("2_5_Item", 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ReadQuestState();
        }
    }

    void ReadQuestState()
    {
        Debug.Log("1_1 is:" + QuestLog.CurrentQuestState("1_1_CleanTheDirt"));
        Debug.Log("1_2 is:" + QuestLog.CurrentQuestState("1_2_Sandwich"));
        Debug.Log("1_3 is:" + QuestLog.CurrentQuestState("1_3_WashPlate"));
        Debug.Log("1_4 is:" + QuestLog.CurrentQuestState("1.4_GrandmaGlasses"));
        Debug.Log("1_5 is:" + QuestLog.CurrentQuestState("1.5_Sister"));

    }

}
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
        ResetDetector();
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
        QuestLog.SetQuestState("3_1_CharityDonate", QuestState.Unassigned);
        QuestLog.SetQuestState("3_3_HelpTheBlind", QuestState.Unassigned);
        QuestLog.SetQuestState("3_4_Beggar", QuestState.Unassigned);
        QuestLog.SetQuestState("3_5_FruitPickUp", QuestState.Unassigned);
        //Dog Task use variable TASK_3_4_HELP/ARRIVE

        //Level 4
        QuestLog.SetQuestState("ToyBubble", QuestState.Unassigned);
        QuestLog.SetQuestState("Get the Balloon", QuestState.Unassigned);
        QuestLog.SetQuestState("BringAED", QuestState.Unassigned);
        QuestLog.SetQuestState("4_2_CollectDust", QuestState.Unassigned);

        //Level 5
        QuestLog.SetQuestState("HoldLift", QuestState.Unassigned);
        QuestLog.SetQuestState("Collect Mask", QuestState.Unassigned);
        QuestLog.SetQuestState("WatsonGreeting", QuestState.Unassigned);
        QuestLog.SetQuestState("WatsonCheckOut", QuestState.Unassigned);



    }

    void ResetPoint()
    {
        //Reset Level Points
        DialogueLua.SetVariable("Point/Level_1", 0);
        DialogueLua.SetVariable("Point/Level_2", 0);
        DialogueLua.SetVariable("Point/Level_3", 0);
        DialogueLua.SetVariable("Point/Level_4", 0);
        DialogueLua.SetVariable("Point/Level_5", 0);

        //Reset Level Variables

        //Level 1
        DialogueLua.SetVariable("1_1_Dirt", 0);
        DialogueLua.SetVariable("1_2_SandWich", 0);
        DialogueLua.SetVariable("1_3_Dirt", 0);
        DialogueLua.SetVariable("1_4_Glasses", false);
        DialogueLua.SetVariable("Grandma_Help", false);


        //Level 2
        DialogueLua.SetVariable("2_1_TeacherItem", 0);
        DialogueLua.SetVariable("2_1_Dustbin", false);
        DialogueLua.SetVariable("2_2_Water", 0);
        DialogueLua.SetVariable("2_5_Item", 0);
        DialogueLua.SetVariable("Pen", 0);
        DialogueLua.SetVariable("Lily_Help", false);
        DialogueLua.SetVariable("Amy_Help", false);
        DialogueLua.SetVariable("Leo_Help", false);


        //Level 3
        DialogueLua.SetVariable("3_1_FirstTime", true);
        DialogueLua.SetVariable("TalkedToSocialWorker", false);
        DialogueLua.SetVariable("DonatedToSocialWorker", false);
        DialogueLua.SetVariable("TalkedToBeggar", false);
        DialogueLua.SetVariable("DonatedToBeggar", false);
        DialogueLua.SetVariable("3_1_CASH", 0);
        DialogueLua.SetVariable("TASK_3_3_COIN", 0);
        DialogueLua.SetVariable("3_5_Fruit", 0);
        DialogueLua.SetVariable("FoundDog", false);
        DialogueLua.SetVariable("CleanDebris", false);

        DialogueLua.SetVariable("TASK_3_2_HELP", false);
        DialogueLua.SetVariable("TASK_3_4_LEAVE", false);
        DialogueLua.SetVariable("TASK_3_4_ARRIVE", false);
        DialogueLua.SetVariable("TASK_3_4_HELP", false);
        DialogueLua.SetVariable("TASK_3_2_DONE", false);

        //Level 4
        DialogueLua.SetVariable("4_2_Leaf", 0);

        DialogueLua.SetVariable("TASK_4_1_HELP", false);
        DialogueLua.SetVariable("TASK_4_1_ARRIVE", false);

        //Level 5
        DialogueLua.SetVariable("5_1_MASK", 0);
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

    private void ResetDetector()
    {
        DialogueLua.SetVariable("3_1_Detect", false);
        DialogueLua.SetVariable("3_2_Detect", false);
        DialogueLua.SetVariable("3_3_Detect", false);
        DialogueLua.SetVariable("3_4_Detect", false);
        DialogueLua.SetVariable("3_5_Detect", false);

        DialogueLua.SetVariable("ToiletGirl_Fisttime", true);
        DialogueLua.SetVariable("5_1_Detect", false);
        DialogueLua.SetVariable("5_2_Detect", false);
        DialogueLua.SetVariable("5_3_Detect", false);
        DialogueLua.SetVariable("5_4_Detect", false);
        DialogueLua.SetVariable("5_5_Detect", false);

        DialogueLua.SetVariable("4_1_Detect", false);
        DialogueLua.SetVariable("4_2_Detect", false);
        DialogueLua.SetVariable("4_3_Detect", false);
        DialogueLua.SetVariable("4_4_Detect", false);
        DialogueLua.SetVariable("4_5_Detect", false);
    }

}
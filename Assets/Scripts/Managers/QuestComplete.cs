using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class QuestComplete : MonoBehaviour
{
    public GameObject menu;

    public AudioClip audioClip;
    public AudioSource audioSource;

    private bool played = false;

    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        /*        Debug.Log("1_1_CleanTheDirt: " + QuestLog.CurrentQuestState("1_1_CleanTheDirt"));
                Debug.Log("1_2_Sandwich: " + QuestLog.CurrentQuestState("1_2_Sandwich"));
                Debug.Log("1_3_WashPlate: " + QuestLog.CurrentQuestState("1_3_WashPlate"));
                Debug.Log("1_4_GrandmaGlasses: " + QuestLog.CurrentQuestState("1_4_GrandmaGlasses"));
                Debug.Log("1_5_Sister: " + QuestLog.CurrentQuestState("1_5_Sister"));*/


        switch(scene.buildIndex)
        {
            case 1:
                {
                    Debug.Log("Now is Level 1");
                    Level_1_Check();
                }
                break;
            case 2:
                {
                    Debug.Log("Now is Level 2");
                    Level_2_Check();
                }
                break;
            case 3:
                {
                    Debug.Log("Now is Level 3");
                    Level_3_Check();

                }
                break;
            case 4:
                {
                    //Debug.Log("Now is Level 4");
                    //Level_4_Check();
                }
                break;
            case 5:
                {
                    //Debug.Log("Now is Level 4");
                    Level_5_Check();
                }
                break;

        }

    }

    private void Level_1_Check()
    {
        if ((QuestLog.CurrentQuestState("1_1_CleanTheDirt") == "abandoned") && (QuestLog.CurrentQuestState("1_2_Sandwich") == "abandoned") && (QuestLog.CurrentQuestState("1_3_WashPlate") == "abandoned") && (QuestLog.CurrentQuestState("1_4_GrandmaGlasses") == "abandoned") && (QuestLog.CurrentQuestState("1_5_Sister") == "success"))
        {
            Debug.Log("Level Complete!");
            menu.SetActive(true);

            audioSource.clip = audioClip;
            if (!played)
            {
                audioSource.Play();
                played = true;
            }

        }
        else
        {
            Debug.Log("If statement not met");
        }
    }

    private void Level_2_Check()
    {
        if ((QuestLog.CurrentQuestState("2.1_TeacherDropItem") == "abandoned") && (QuestLog.CurrentQuestState("2.2_WaterPour") == "abandoned") && (QuestLog.CurrentQuestState("2.3_FindPen") == "abandoned") && (QuestLog.CurrentQuestState("2.4_ComfortClassmate") == "success") && (QuestLog.CurrentQuestState("2.5_Organize") == "abandoned"))
        {
            Debug.Log("Level Complete!");
            menu.SetActive(true);

            audioSource.clip = audioClip;
            if (!played)
            {
                audioSource.Play();
                played = true;
            }

        }
        else
        {
            Debug.Log("If statement not met");
        }
    }

    private void Level_3_Check()
    {
        if ((Lua.Run("return Variable['3_1_Detect']").AsBool) && (Lua.Run("return Variable['3_2_Detect']").AsBool) && (Lua.Run("return Variable['3_3_Detect']").AsBool) && (Lua.Run("return Variable['3_4_Detect']").AsBool) && (Lua.Run("return Variable['3_5_Detect']").AsBool))
        {
            Debug.Log("Level Complete!");
            menu.SetActive(true);

            audioSource.clip = audioClip;
            if (!played)
            {
                audioSource.Play();
                played = true;
            }

        }
        else
        {
            Debug.Log("If statement not met");
        }
    }

    private void Level_5_Check()
    {
        if ((QuestLog.CurrentQuestState("Collect Mask") == "success") && (QuestLog.CurrentQuestState("HoldLift") == "abandoned") && (QuestLog.CurrentQuestState("WatsonCheckOut") == "success") && (QuestLog.CurrentQuestState("5_5_Phone") == "abandoned"))
        {
            Debug.Log("Level Complete!");
            menu.SetActive(true);

            audioSource.clip = audioClip;
            if (!played)
            {
                audioSource.Play();
                played = true;
            }

        }
        else
        {
            Debug.Log("If statement not met");
        }
    }


}

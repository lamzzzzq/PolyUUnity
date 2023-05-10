using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestComplete : MonoBehaviour
{
    public GameObject menu;

    public AudioClip audioClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

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
            menu.SetActive(true);

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.Log("If statement not met");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Helper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BringAED()
    {
        //DialogueLua.SetVariable("TASK_4_4_ARRIVE", true);

        QuestLog.SetQuestState("BringAED", QuestState.Success);
    }
}

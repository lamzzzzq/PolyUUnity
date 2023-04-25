using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class DetectStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string cash = DialogueLua.GetVariable("TASK_3_1_CASH").asString;
        Debug.Log(cash);
/*        if (Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("yesssssss");
            string cash = DialogueLua.GetVariable("TASK_3_1_CASH").asString;
            Debug.Log(cash);
        }*/
    }
}

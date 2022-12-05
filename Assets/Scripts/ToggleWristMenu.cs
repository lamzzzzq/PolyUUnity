using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class ToggleWristMenu : MonoBehaviour
{

    public GameObject WristMenu;
    public bool Show;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.M)) || (InputBridge.Instance.XButtonDown))
        {
            Show = !Show;
            int score = DialogueLua.GetVariable("TASK_3_1_CASH").AsInt;
            Debug.Log(score);
        }

        if(Show)
        {
            WristMenu.SetActive(true);
        }

        if(!Show)
        {
            WristMenu.SetActive(false);
        }
    }
}

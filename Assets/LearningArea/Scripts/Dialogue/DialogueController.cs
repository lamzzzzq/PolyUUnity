using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO currentData;
    [SerializeField] private bool canTalk = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&& currentData != null)
        {
            canTalk = true;

        }
    }

    private void Update()
    {
        if(canTalk && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
        {
            OpenDialogue();
        }
    }

    void OpenDialogue()
    {
        //打开UI面板
        //传输对话内容信息
        DialogueUI.Instance.UpdateDialogueData(currentData);

        DialogueUI.Instance.UpdateMainDialogue(currentData.dialoguePiceces[0]);

    }


}

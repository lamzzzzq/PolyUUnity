using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LoadingOnPlayer : MonoBehaviour
{
    public Loading loading;
    public GameObject scoreObj;
    public Camera myCamera; // ��������
    public GameObject cullingObj;

    public GameObject teacher;



    private void Start()
    {

    }


    public void SwitchToNormal()
    {
        // ��Ⱦ���в㣬���˵�12��
        cullingObj.SetActive(false);
        scoreObj.SetActive(true);

        continueConversation();
    }

    public void continueConversation()
    {
        QuestLog.SetQuestState("Classroom_TASK_2", QuestState.Active);
        foreach (var item in teacher.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }

    public void endClass()
    {

    }



}

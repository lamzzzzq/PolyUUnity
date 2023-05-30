using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;
using PixelCrushers.DialogueSystem;

public class HelpTeacher : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public Vector3 rotationDegree_1;
    public Transform playerPosition;

    public TeleportPlayerFade teleport;

    public GameObject teacher;

    public List<GameObject> npcToShow;
    public List<GameObject> npcToHide;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();

        //disable controller
        //DisablePlayerController();
    }

    public void TransformAndHelp()
    {
        StartCoroutine(SetActiveAndTalk());
    }

    public void EnablePlayerController()
    {
        playerController.enabled = true;
    }

    public void DisablePlayerController()
    {
        playerController.enabled = false;
    }

    
    private IEnumerator SetActiveAndTalk()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);
        yield return new WaitForSeconds(1f);
        teacher.GetComponent<DialogueSystemTrigger>().OnUse();
        foreach (var item in npcToShow)
        {
            item.SetActive(true);
        }

        foreach (var item in npcToHide)
        {
            item.SetActive(false);
        }

    }


    public void RefuseToHelp()
    {
        StartCoroutine(RefuseAndSetActive());
    }

    private IEnumerator RefuseAndSetActive()
    {
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);

        yield return new WaitForSeconds(1f);
        //Disable & Enable
        foreach (var item in npcToShow)
        {
            item.SetActive(true);
        }

        foreach (var item in npcToHide)
        {
            item.SetActive(false);
        }

        teacher.SetActive(false);
        EnablePlayerController();

        QuestLog.SetQuestState("2.1_TeacherDropItem", QuestState.Abandoned);
    }
    public void EnablePlayerControllerDelay()
    {
        StartCoroutine(enableController());
    }


    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(2f);
        playerController.enabled = true;
    }
}

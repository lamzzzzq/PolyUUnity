using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class WheelChairOnPlayer : MonoBehaviour
{
    private CharacterController playerController;
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform playerPosition;
    public Transform playerPosition_faceNPC;
    public Transform NPCPosition_facePlayer;
    public Transform playerPosition_faceBack;
    public GameObject Arrow;
    public GameObject canvasEntry;

    public FacePlayerNormal facePlayer;

    private bool trigger = false;
    public GameObject NPC;

    public GameObject wheelChairCanvas;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject NPCtoHide, NPCtoShow;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void TransportToOrder()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        Arrow.SetActive(true);

        StartCoroutine(enableController());
    }
    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(2);
        playerController.enabled = true;
        Debug.Log("Run");
    }




    public void NPCWalkAndTalk()
    {
        StartCoroutine(NPCtalk());
    }


    private IEnumerator NPCtalk()
    {
        //fade in / out & playerPosition_faceNPC
        teleport.ResetPlayerPosRotWithParameters(playerPosition_faceNPC, screenFader);

        //NPC nav
        NPC.transform.position = NPCPosition_facePlayer.position;
        facePlayer.enabled = true;

        yield return new WaitForSeconds(2);




        //NPC talk
        foreach (var trigger in NPC.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }

    public void FadeAndNPCDisappear()
    {
        //fade in / out
        teleport.ResetPlayerPosRotWithParameters(playerPosition_faceBack, screenFader);

        NPCtoHide.SetActive(false);
        NPCtoShow.SetActive(true);

        //NPC disappear
        canvasEntry.SetActive(true);

        //dialogue SHOW
        StartCoroutine(enableController());
    }

    public void PlaceTray()
    {
        QuestLog.SetQuestState("Canteen_TASK_3", QuestState.Abandoned);

        teleport.ResetPlayerPosRotWithParameters(transform, screenFader);

        NPC.transform.position = NPCPosition_facePlayer.position;
        NPC.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void NPCTalk()
    {
        NPC.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void WheelChairEvent()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1);
        teleport.ResetPlayerPosRotWithParameters(transform, screenFader);
        StartCoroutine(invokeFruitEvent());
        playerController.enabled = false;
    }

    private IEnumerator invokeFruitEvent()
    {
        yield return new WaitForSeconds(1f);
        //Play audio clip
        audioSource.PlayOneShot(audioClip);
        wheelChairCanvas.SetActive(true);
        StartCoroutine(PlayAudioAndEnableButton());
    }

    private IEnumerator PlayAudioAndEnableButton()
    {
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = wheelChairCanvas.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

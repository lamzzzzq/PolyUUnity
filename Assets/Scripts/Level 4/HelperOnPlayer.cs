using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class HelperOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public TeleportPlayerFade teleport;
    public Transform playerPosition;
    public Transform TeleportPlayerPosition;

    public Transform TeleportPlayerPosition_1;
    public Transform TeleportPlayerPosition_2;

    public UnityEvent npcEvents;
    public GameObject HelperObj_1,HelperObj_2,basketball;
    public GameObject HelperConversationObj;
    public GameObject canvas;
    private bool trigger = false;
    private CharacterController playerController;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Collider ballonTrigger;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    

    public void AskForHelp()
    {
        if(!trigger)
        {
            StartCoroutine(AskForHelpAndShowCanvas());
            trigger = true;
        }
    }

    private IEnumerator AskForHelpAndShowCanvas()
    {
        //disable movement
        playerController.enabled = false;
        //fade in/out
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);

        //set active NPC
        HelperObj_1.SetActive(true);
        HelperObj_2.SetActive(true);
        basketball.SetActive(true);

        //finish 4_3
        DialogueLua.SetVariable("4_3_Detect",true);

        //Play audio clip
        audioSource.PlayOneShot(audioClip);
        //Show canvas
        canvas.SetActive(true);
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = canvas.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }

        public void TeleportAndTalk()
    {
        StartCoroutine(TeleportationAndTalk());
    }

    private IEnumerator TeleportationAndTalk()
    {
        playerController.enabled = false;
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition, ScreenFader);

        yield return new WaitForSeconds(1f);
        HelperConversationObj.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void Refuse()
    {
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        playerController.enabled = true;
    }

    public void SuccessAndFaceBack()
    {
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition_2, ScreenFader);
        HelperObj_1.SetActive(false);
        HelperObj_2.SetActive(false);
        StartCoroutine(enableController());

    }

    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(3);
        playerController.enabled = true;
        Debug.Log("Run");
        ballonTrigger.enabled = true;

    }

    public void EnableBallonTrigger()
    {
        ballonTrigger.enabled = true;
    }

    public void TeleportToPlace()
    {
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition_1, ScreenFader);
    }
}

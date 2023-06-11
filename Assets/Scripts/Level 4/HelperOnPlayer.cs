using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class HelperOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public TeleportPlayerFade teleport;
    public Transform playerPosition;
    public Transform TeleportPlayerPosition;

    public UnityEvent npcEvents;
    public GameObject HelperObj;
    public GameObject HelperConversationObj;
    public GameObject canvas;
    private bool trigger = false;
    private CharacterController playerController;
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

        HelperObj.SetActive(true);

        yield return new WaitForSeconds(2f);
        
        //show canvas
        canvas.SetActive(true);
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
    }

    public void SuccessAndFaceBack()
    {
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition, ScreenFader);
        playerController.enabled = true;
    }
}

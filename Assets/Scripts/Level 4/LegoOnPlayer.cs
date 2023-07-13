using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class LegoOnPlayer : MonoBehaviour
{
    public CharacterController playerController;
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform playerPosition;

    public GameObject ballon;
    public GameObject ballonNPC;

    public GameObject TeleportPlayerPosition;

    public Transform grabBalloonPosition;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Transform legoObj;

    public GameObject balloon;
    public GameObject balloonPrevious;


    private bool trigger = false;

    private void Start()
    {
        //playerController = GetComponent<CharacterController>();
    }

    public void AskForHelp()
    {
        if (!trigger)
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
        teleport.ResetPlayerPosRotWithParameters(transform, screenFader);


        yield return new WaitForSeconds(1);
        //Play audio clip
        //audioSource.PlayOneShot(audioClip);

        //yield return new WaitForSeconds(audioClip.length);

        //NPC runs & Ballon flys
        ballon.GetComponent<BallonFly>().enabled = true ;
        ballonNPC.GetComponent<BallonGirl>().enabled = true;
    }

    public void TeleportAndTalk()
    {
        StartCoroutine(TeleportationAndTalk());
    }

    private IEnumerator TeleportationAndTalk()
    {
        playerController.enabled = false;
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition.transform, screenFader);

        DialogueLua.SetVariable("4_4_Detect", true);

        yield return new WaitForSeconds(1f);

        foreach (var item in ballonNPC.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }

    public void TeleporAndNPCWalksAway()
    {
        playerController.enabled = false;
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition.transform, screenFader);

        DialogueLua.SetVariable("4_4_Detect", true);
    }

    private IEnumerator TeleportationAndNPCComes()
    {
        playerController.enabled = false;
        teleport.ResetPlayerPosRotWithParameters(TeleportPlayerPosition.transform, screenFader);

        yield return new WaitForSeconds(1f);

        foreach (var item in ballonNPC.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }





    public void Refuse()
    {
        teleport.ResetPlayerPosRotWithParameters(transform, screenFader);
        playerController.enabled = true;
    }

    public void StepOnLego()
    {
        //Disable Movement
        playerController.enabled = false;

        StartCoroutine(teleportCoroutine());

    }

    private IEnumerator teleportCoroutine()
    {
        yield return new WaitForSeconds(2);

        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);

        //Move Lego position
        legoObj.transform.position = new Vector3(-22.02f, 0.55f, -8.31f);
    }


    public void TouchBalloon()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(grabBalloonPosition, screenFader);

        //Enable Balloon
        balloon.SetActive(true);
        balloonPrevious.SetActive(false);

        //StartConversation
        foreach (var item in ballonNPC.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }

}

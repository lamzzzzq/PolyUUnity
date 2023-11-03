using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class BubbleCarOnPlayer : MonoBehaviour
{
    private CharacterController playerController;
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform playerPosition;
    public Transform facePosition;
    public Transform exitPosition;
    public Transform startingPosition;
    public Transform bubbleCanvasPosition;
    public GameObject confirmUI;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool trigger = false;

    public GameObject gunBoy;


    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void TransportOnJet()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        confirmUI.SetActive(false);
    }

    public void TransportToStartingPosition()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(startingPosition, screenFader);
        //confirmUI.SetActive(false);
        playerController.enabled = true;
    }

    public void ExitJet() 
    {
        teleport.ResetPlayerPosRotWithParameters(exitPosition, screenFader);

        StartCoroutine(enableController());
    }

    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(3);
        playerController.enabled = true;
        Debug.Log("Run");
    }

    public void RefuseAndTeleportationwithFade()
    {
        Debug.Log("Refuse");
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        //change the position of GunBoy
        gunBoy.GetComponent<GunBoy>().TeleportNPC();
    }

    public void teleportToCanvasAndPlayAudio()
    {
        if (!trigger)
        { 
            //Disable Movement
            playerController.enabled = false;
            //Transport to a position and specific rotation degrees
            teleport.ResetPlayerPosRotWithParameters(bubbleCanvasPosition, screenFader);

            //show Canvas
            confirmUI.SetActive(true);
            //Play audio
            audioSource.PlayOneShot(audioClip);
            trigger = true;
        }
    }

    public void faceNPC()
    {
        teleport.ResetPlayerPosRotWithParameters(facePosition, screenFader);
    }


}

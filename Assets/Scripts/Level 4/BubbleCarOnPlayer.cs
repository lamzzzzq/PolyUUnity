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
    public Transform exitPosition;
    public Transform startingPosition;
    public GameObject confirmUI;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class WalletOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public TeleportPlayerFade teleport;
    public Vector3 rotationDegree_1;
    public Transform playerPosition;
    public Transform teleportPlayerPosition;
    public GameObject phonePerson;
    public Transform teleportation_firstFloor;


    public UnityEvent npcEvents;
    //public GameObject WalletPeople;
    private bool disableMovement = false;
    private CharacterController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void WalletPeopleEvent()
    {
        if (!disableMovement)
        {
            playerController.enabled = false;
            disableMovement = true;
        }

        teleport.ResetPlayerPosRotWithParameters(teleportPlayerPosition, ScreenFader);
        StartCoroutine(invokeWalletEvent());

    }

    private IEnumerator invokeWalletEvent()
    {
        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
    }

    public void HelpAndFade()
    {
        StartCoroutine(HelpAndPickUp());
    }

    private IEnumerator HelpAndPickUp()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);
        playerController.enabled = true;

        yield return null;
    }

    public void RefuseToHelp()
    {
        playerController.enabled = true;
    }

    public void TransportAndTalk()
    {
        StartCoroutine(TransportAndTalkToNPC());
    }

    private IEnumerator TransportAndTalkToNPC()
    {
        yield return new WaitForSeconds(1f);
        teleport.ResetPlayerPosRotWithParameters(teleportation_firstFloor, ScreenFader);
        playerController.enabled = true;

        phonePerson.GetComponent<DialogueSystemTrigger>().OnUse();
    }

}

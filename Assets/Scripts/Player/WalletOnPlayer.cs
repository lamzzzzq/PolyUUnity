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
    //public Vector3 rotationDegree_1;
    public Transform playerPosition;
    public Transform teleportPlayerPosition;
    public GameObject phonePerson;
    public Transform teleportation_firstFloor;
    public PhonePersonOntheGround groundNPC;


    public UnityEvent npcEvents;
    //public GameObject WalletPeople;
    private bool disableMovement = false;
    private CharacterController playerController;

    public GameObject player;
    public GameObject Phone_1;
    public GameObject Phone_2;
    Grabbable grabbable;
    Grabber grabber;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        grabber = player.GetComponent<Grabber>();
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
        playerController.enabled = false;
        teleport.ResetPlayerPosRotWithParameters(teleportation_firstFloor, ScreenFader);
        Release();
        yield return new WaitForSeconds(1);
        playerController.enabled = true;
        Pick();
        groundNPC.WalkToPlayer();



        //phonePerson.GetComponent<DialogueSystemTrigger>().OnUse();
    }



    public void Release()
    {

        grabbable = Phone_1.GetComponentInChildren<Grabbable>();

        if (grabbable != null)
        {
            grabbable.CanBeDropped = true;
        }
        if (grabber != null)
        {
            grabber.TryRelease();
        }

        Phone_1.SetActive(false);
    }
    
    public void Pick()
    {
        if (grabber != null && !grabber.HoldingItem)
        {
            var go = GameObject.Instantiate(Phone_2, grabber.transform.position, Quaternion.identity);

            grabbable = go.GetComponent<Grabbable>();

            grabber.GrabGrabbable(grabbable);

        }

        StartCoroutine(changePhoneProp());

    }

    private IEnumerator changePhoneProp()
    {
        yield return new WaitForSeconds(0.5f);

        grabbable.CanBeDropped = true;

        grabbable.GrabPhysics = GrabPhysics.Velocity;
    }
}

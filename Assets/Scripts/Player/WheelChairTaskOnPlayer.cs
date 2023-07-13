using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class WheelChairTaskOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public TeleportPlayerFade teleport;
    public Vector3 rotationDegree_1;
    public Transform playerPosition;


    public UnityEvent npcEvents;
    public GameObject CustomerObj;
    private bool disableMovement = false;
    private CharacterController playerController;

    public bool triggerLeft;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void WheelChairAction_1()
    {
        Debug.Log("Player Controller Enabled: first " + playerController.enabled);
        if (!disableMovement)
        {
            playerController.enabled = false;
            disableMovement = true;
        }
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        Debug.Log("Player Controller Enabled: second" + playerController.enabled);
        StartCoroutine(invokeWheeChairEvent());
    }

    private IEnumerator invokeWheeChairEvent()
    {
        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
        triggerLeft = true;
    }

    public void WheelChairAction_2()
    {
        Debug.Log("Player Controller Enabled: first " + playerController.enabled);
        if(!disableMovement)
        {
            playerController.enabled = false;
            disableMovement = true;
        }

        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        Debug.Log("Player Controller Enabled: second" + playerController.enabled);
        StartCoroutine(invokeWheeChairEventSecond());
    }

    private IEnumerator invokeWheeChairEventSecond()
    {
        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
        triggerLeft = false;
    }



    public void FadeAndTransportToTalk()
    {
        StartCoroutine(HelpCustomer());
    }

    private IEnumerator HelpCustomer()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);

        yield return new WaitForSeconds(1f);
        CustomerObj.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void FadeAndTransportNoHelp()
    {
        StartCoroutine(NoHelpCustomer());
    }

    private IEnumerator NoHelpCustomer()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);

        yield return null;
    }

    public void DoneTask_5_1()
    {
        DialogueLua.SetVariable("5_1_Detect", true);
    }


    public void DoneTask_5_4()
    {
        DialogueLua.SetVariable("5_4_Detect", true);
    }

    public void DoneTask_5_5()
    {
        DialogueLua.SetVariable("5_5_Detect", true);
    }
}

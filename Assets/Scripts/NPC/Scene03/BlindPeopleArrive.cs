using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;


public class BlindPeopleArrive : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public Vector3 rotationDegree_1;

    public TeleportPlayerFade teleport;
    public Transform PlayerPosition;
    public Transform PlayerPosition_LookAtBlind;

    public GameObject blindPeople;
    public GameObject blindPeopleTrigger;

    private CharacterController playerController;

    private bool firstTime = false;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void BlindPeopleArriveDes()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);
        
        blindPeople.SetActive(false);
        playerController.enabled = true;
    }

    public void firstTimeBlind()
    {
        if(!firstTime)
        {
            playerController.enabled = false;
            firstTime = true;
        }

        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_LookAtBlind, ScreenFader);
        blindPeople.GetComponent<BlindPeople>().WalkTowardTheDestination();
        EnableController();
        blindPeopleTrigger.SetActive(false);
    }

    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(3f);
        playerController.enabled = true;
    }

    public void EnableController()
    {
        StartCoroutine(enableController());
    }
}

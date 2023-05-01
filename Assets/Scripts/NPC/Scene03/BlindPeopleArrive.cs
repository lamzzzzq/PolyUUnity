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

    public GameObject blindPeople;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void BlindPeopleArriveDes()
    {
        teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        playerController.enabled = true;
        blindPeople.SetActive(false);
    }


}

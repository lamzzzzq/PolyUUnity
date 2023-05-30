using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class DogOwnerFadeAndTransportOnPlayer : MonoBehaviour
{
    public Transform PlayerPosition_1;
    public Transform PlayerPosition_2;
    public ScreenFader ScreenFader;
    public Vector3 rotationDegree_1;
    public Vector3 rotationDegree_2;
    public GameObject player;

    public TeleportPlayerFade teleport;

    public UnityEvent npcEvents;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void DogOwnerCutsceneFirst()
    {
        
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_1, ScreenFader);
        player.transform.rotation = Quaternion.Euler(rotationDegree_1);
        npcEvents.Invoke();
    }

    public void DogOwnerCutsceneSecond()
    {
        
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_2, ScreenFader);
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_2);
        StartCoroutine(enableController());
    }

    private IEnumerator enableController()
    {
        yield return new WaitForSeconds(2f);
        playerController.enabled = true;
    }

    public void EnableController()
    {
        StartCoroutine(enableController());
    }
}

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
    public GameObject confirmUI;

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
}

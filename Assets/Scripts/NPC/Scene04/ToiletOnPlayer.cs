using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class ToiletOnPlayer : MonoBehaviour
{
    public Transform PlayerPosition;
    public ScreenFader ScreenFader;

    public Transform toiletPlayerPosition_Finish;
    public Transform toiletPlayerPosition_Refuse;

    public UnityEvent npcEvents;
    public GameObject NPC;

    public TeleportPlayerFade teleport;

    private CharacterController playerController;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void TransportationAndTalk()
    {
        //player teleport to position
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);

        npcEvents.Invoke();
    }

    public void FinishAndWalkToward()
    {
        //Disable Movement
        playerController.enabled = false;
        //Teleport
        teleport.ResetPlayerPosRotWithParameters(toiletPlayerPosition_Finish, ScreenFader);
        //NPC walk towards
        NPC.GetComponent<ToiletKid>().enabled = true;
    }

    public void RefuseAndWalkToward()
    {
        //Disable Movement
        playerController.enabled = false;
        //Teleport
        teleport.ResetPlayerPosRotWithParameters(toiletPlayerPosition_Refuse, ScreenFader);
        //NPC walk towards
        NPC.GetComponent<ToiletKid>().enabled = true;
    }


}

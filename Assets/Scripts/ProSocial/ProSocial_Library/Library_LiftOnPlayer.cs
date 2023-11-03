using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class Library_LiftOnPlayer : MonoBehaviour
{
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public Transform PlayerPosition_First;
    public Transform PlayerPosition_Second;

    public Animator DoorAnimator;
    private CharacterController playerController;
    public Transform playerPosition;
    public Library_LiftNPC liftNPC;

    public Animator wheelChairBoy;

    public bool isPress = false;
    public int pressCount;
    private bool time = false;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(!isPress && pressCount == 2)
        {
            teleportToSecondFloor();
            isPress = true;

            wheelChairBoy.SetBool("Move",true);
        }
    }

    // Update is called once per frame

    public void teleportToSecondFloor()
    {
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_Second, ScreenFader);
    }

    public void teleportToFirstFloor()
    {
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_First, ScreenFader);
    }

    public void openTheDoor()
    {
        DoorAnimator.SetBool("isOpen", true);
        DoorAnimator.SetBool("isClose", false);
    }

    public void closeTheDoor()
    {
        DoorAnimator.SetBool("isClose", true);
        DoorAnimator.SetBool("isOpen", false);
    }

    public void npcWalksInAndTalk()
    {

        if(!time)
        {
            //disble player movement
            playerController.enabled = false;

            //teleport position
            teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);

            //npc walks inside
            liftNPC.WalkTowardTheLift();


        }
        time = true;
        Debug.Log("no.....");

        //npc talks
    }

    public void updatePressCount()
    {
        pressCount++;
    }




}

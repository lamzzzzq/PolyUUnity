using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class WheelChairOnPlayer_Classroom : MonoBehaviour
{
    public ScreenFader screenFader;
    public TeleportPlayerFade teleport;
    private CharacterController playerController;

    public Transform playerFirstPosition;
    public Transform playerSecondPosition;
    public GameObject wheelChairBoy;
    public Transform playerSeatedPosition;

    public BoxCollider seat;

    public WheelChairBoy wheelChairBoyScript;

    private void Start()
    {
        playerController = this.GetComponent<CharacterController>();
    }

    
    //Fade In Out - 玩家在特定的位置，看着轮椅走进area


    //Fade In Out - 玩家在特定的位置，和轮椅对话

    public void FirstEvent()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerFirstPosition, screenFader);

        wheelChairBoyScript.moveToArea();
        QuestLog.SetQuestState("Classroom_TASK_1", QuestState.Abandoned);
        StartCoroutine(SecondEvent());
    }

    private IEnumerator SecondEvent()
    {
        yield return new WaitForSeconds(3f);

        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerSecondPosition, screenFader);

        foreach (var item in wheelChairBoy.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }

    public void playerSeated()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerSeatedPosition, screenFader);
    }

    public void enableController()
    {
        playerController.enabled = true;
    }

    public void enableSeatTrigger()
    {
        seat.enabled = true;
    }
}

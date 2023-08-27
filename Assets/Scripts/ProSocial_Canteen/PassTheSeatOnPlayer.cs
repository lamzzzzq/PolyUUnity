using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class PassTheSeatOnPlayer : MonoBehaviour
{
    public Transform SeatPosition;
    public Transform SeatPosition_Second;
    public ScreenFader ScreenFader;

    public TeleportPlayerFade teleport;
    public GameObject NPC;

    public GameObject QueueNPC_Standing;
    public GameObject QueueNPC_Sitting;
    public GameObject NPCStanding;
    public GameObject NPCSitting;
    public GameObject food;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    public void CallResetPlayerPosRotWithSpecificParameters()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(SeatPosition, ScreenFader);

        QueueNPC_Sitting.SetActive(true);
        QueueNPC_Standing.SetActive(false);
    }

    public void FadeAndTalk()
    {
        teleport.ResetPlayerPosRotWithParameters(SeatPosition, ScreenFader);
        NPCStanding.SetActive(true);
        foreach (var trigger in NPC.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }

    public void AgreeToleave()
    {
        teleport.ResetPlayerPosRotWithParameters(SeatPosition, ScreenFader);

        //NPC sits
        NPCStanding.SetActive(false);
        //NPC standing
        NPCSitting.SetActive(true);

        //Food Enable
        food.SetActive(true);

        //Player and food move to other place
        teleport.ResetPlayerPosRotWithParameters(SeatPosition_Second, ScreenFader);
    }
}

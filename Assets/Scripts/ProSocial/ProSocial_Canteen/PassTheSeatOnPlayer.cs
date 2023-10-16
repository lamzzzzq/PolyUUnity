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
    public GameObject eatCanvas;

    public GameObject QueueNPC_Standing;
    public GameObject QueueNPC_Sitting;
    public GameObject NPCStanding;
    public GameObject NPCSitting;
    public GameObject food;
    public GameObject NPCStandingTalking;
    public GameObject firstPanToHide;
    public GameObject firstPanToShow;

    public GameObject NPCSittingObj;
    public GameObject NPCWalkingObj;
    public WalkAwayNPC walkAwayNPC;

    public OrderManager orderManager;
    public GameObject NPCfood;


    //public FoodInteraction foodInteraction;

    public int eatFood=0;

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
        bool playOnce = false;
        if(eatFood == 2 && !playOnce)
        {
            teleport.ResetPlayerPosRotWithParameters(SeatPosition, ScreenFader);
            eatCanvas.SetActive(false);
            NPCStanding.SetActive(true);
            NPCStandingTalking.SetActive(false);
            orderManager.DeactivateTableMeal_BeforeAsk();
            orderManager.MealOnTableForGrab();

            foreach (var trigger in NPC.GetComponents<DialogueSystemTrigger>())
            {
                trigger.OnUse();
            }
            playOnce = true;
            //foodInteraction.OnGrab();
        
        }

        

    }

    public void AgreeToleave()
    {
        //teleport.ResetPlayerPosRotWithParameters(SeatPosition, ScreenFader);

        //NPC sits
        NPCStanding.SetActive(false);
        //NPC standing
        NPCSitting.SetActive(true);

        //Food Enable
        //food.SetActive(true);

        //Player and food move to other place
        teleport.ResetPlayerPosRotWithParameters(SeatPosition_Second, ScreenFader);

        playerController.enabled = false;
    }

    public void StopAllConversations()
    {
        for (int i = DialogueManager.instance.activeConversations.Count - 1; i >= 0; i--)
        {
            DialogueManager.instance.activeConversations[i].conversationController.Close();
        }
    }

    public void Eat()
    {
        eatFood++;
        Debug.Log("Eat");
    }

    public void TurnAroundAndNPCWalkAway()
    {
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        NPCfood.SetActive(false);

        NPCSittingObj.SetActive(false);
        NPCWalkingObj.SetActive(true);

        walkAwayNPC.moveToDestination();
    }

}

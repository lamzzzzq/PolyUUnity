using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class LiftOnPlayer : MonoBehaviour
{
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public Transform PlayerPosition;
    public LiftBehaviour liftBehaviour;
    private bool liftOpen = false;

    public void StartConversation()
    {
        if(!liftOpen)
        {
            StartCoroutine(Conversation());
        }
        liftOpen = true;
    }

    private IEnumerator Conversation()
    {
        yield return new WaitForSeconds(1f);

        //teleport.targetRowwtation = Quaternion.Euler(rotationDegree);
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);

        liftBehaviour.StartLift();
    }

    public void DoneTask_5_2()
    {
        DialogueLua.SetVariable("5_2_Detect", true);
    }

}

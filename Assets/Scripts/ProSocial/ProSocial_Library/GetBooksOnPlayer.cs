using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class GetBooksOnPlayer : MonoBehaviour
{
    public CharacterController playerController;
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform playerPosition;
    public Transform playerPosition_Second;

    public GameObject bookNPC;

    // Start is called before the first frame update
    public void StepOnLego()
    {
        //Disable Movement
        playerController.enabled = false;

        StartCoroutine(teleportCoroutine());

    }

    private IEnumerator teleportCoroutine()
    {
        yield return new WaitForSeconds(2);

        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);

    }


    public void TouchBook()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerPosition_Second, screenFader);

        //Enable Balloon
        QuestLog.SetQuestState("Library_TASK_3", QuestState.Abandoned);

        //StartConversation
        foreach (var item in bookNPC.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }

    public void enableController()
    {
        playerController.enabled = true;
    }
}

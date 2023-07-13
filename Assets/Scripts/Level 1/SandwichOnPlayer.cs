using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class SandwichOnPlayer : MonoBehaviour
{
    public GameFlow gameFlow;
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public GameObject mother;

    private bool done = false;
    private bool cleanDirt = false;
    private bool washPlate = false;

    public Transform playerPosition;
    // Update is called once per frame
    void Update()
    {
        if ((gameFlow.score == 2) && (done == false))
        {
            Debug.Log("Sandwich Finished!");
            if(!done)
            {
                Debug.Log("Excute Fade and Talk!");
                FadeAndStartConversation();
            }
            done = true;
        }

        if((DialogueLua.GetVariable("1_1_Dirt").asInt == 10) && !cleanDirt)
        {
            FadeAndStartConversation();
            cleanDirt = true;
        }

        if ((DialogueLua.GetVariable("1_3_Dirt").asInt == 15) && !washPlate)
        {
            FadeAndStartConversation();
            washPlate = true;
        }
    }

    private void FadeAndStartConversation()
    {
        StartCoroutine(FadeAndTalk());
    }

    private IEnumerator FadeAndTalk()
    {
        yield return new WaitForSeconds(1);
        teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);
        foreach (var trigger in mother.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}

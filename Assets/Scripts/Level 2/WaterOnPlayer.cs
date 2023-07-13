using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class WaterOnPlayer : MonoBehaviour
{
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public Transform PlayerPosition;

    public GameObject waterGirl;

    private bool finished = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(DialogueLua.GetVariable("2_2_Water").asInt == 7 && !finished)
        {
            TeleportAndTalk();
            finished = true;
        }
    }

    public void TeleportAndTalk()
    {
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);

        foreach (var trigger in waterGirl.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}

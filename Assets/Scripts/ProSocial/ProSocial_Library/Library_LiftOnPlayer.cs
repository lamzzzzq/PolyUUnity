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

    // Start is called before the first frame update

    // Update is called once per frame
    
    public void teleportToSecondFloor()
    {
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_Second, ScreenFader);
    }

    public void teleportToFirstFloor()
    {
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition_First, ScreenFader);
    }

}

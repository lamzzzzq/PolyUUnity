using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class BubbleGunLogic : MonoBehaviour
{
    public Transform JetPosition;
    public ScreenFader ScreenFader;
    public Vector3 rotationDegree;

    public TeleportPlayerFade teleport;

    public void CallResetPlayerPosRotWithSpecificParameters()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(JetPosition, ScreenFader);
    }
}

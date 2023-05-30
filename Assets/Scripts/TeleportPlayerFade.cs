using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class TeleportPlayerFade : MonoBehaviour
{
    public Transform target;
    public ScreenFader fader;

    public void CallFadeIn()
    {
        fader.DoFadeIn();
    }

    public void CallFadeOut()
    {
        fader.DoFadeOut();
    }

    public void ResetPos()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    public void ResetPlayerPosRot()
    {
        CallFadeIn();
        Invoke(nameof(ResetPlayer), 1f);
    }

    public void ResetPlayerPosRotWithParameters(Transform newTarget, ScreenFader newFader)
    {
        // Update the target and fader with the provided parameters
        target = newTarget;
        fader = newFader;

        // Call the existing method
        ResetPlayerPosRot();

    }

    private void ResetPlayer()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        CallFadeOut();
    }
}

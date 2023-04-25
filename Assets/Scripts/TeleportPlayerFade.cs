using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class TeleportPlayerFade : MonoBehaviour
{
    public Transform target;
    public ScreenFader fader;
    public Quaternion targetRotation;
    //public TeleportPlayerFadeEvent onTeleport;
    //  the screen fader on the center eye camera, drag the camera here
    //[SerializeField] float fadeInWait = 0.5f;

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
        transform.rotation = targetRotation;
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

    public void ResetPlayer()
    {
        transform.position = target.position;
        transform.rotation = targetRotation;
        CallFadeOut();
    }

    public void FadeCutscene()
    {
        fader.DoFadeIn();
        Invoke(nameof(FadeSecond), 1f);

        Debug.Log("2");
    }

    public void FadeSecond()
    {
        CallFadeOut();
        Debug.Log("1");

    }
}
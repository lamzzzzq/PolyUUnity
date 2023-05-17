using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ScreenFadeNPCDisappear : MonoBehaviour
{
    public GameObject NPC;
    public ScreenFader fader; //  the screen fader on the center eye camera, drag the camera here
    //[SerializeField] float fadeInWait = 0.5f;

    public void CallFadeIn()
    {
        fader.DoFadeIn();
    }

    public void CallFadeOut()
    {
        fader.DoFadeOut();
    }

    IEnumerator WaitFadeAndNPCDisappear()
    {
        yield return new WaitForSeconds(1);
        CallFadeIn();
        Invoke(nameof(DisableNPC), 0.5f);
    }


    public void FadeAndTeacherDisappear()
    {
        /*        CallFadeIn();
                Invoke(nameof(DisableFather), 1f);*/
        StartCoroutine(WaitFadeAndNPCDisappear());
    }

    public void DisableNPC()
    {
        //NPC.SetActive(false);
        CallFadeOut();
    }

    /*    public void FadeCutscene()
        {
            fader.DoFadeIn();
            Invoke(nameof(FadeSecond), 1f);

            Debug.Log("2");
        }*/

    public void FadeSecond()
    {
        CallFadeOut();
        Debug.Log("1");
    }
}
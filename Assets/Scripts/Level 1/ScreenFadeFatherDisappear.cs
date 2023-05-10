using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ScreenFadeFatherDisappear : MonoBehaviour
/*{
    public GameObject father;
    public GameObject block;
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

    IEnumerator WaitFadeAndFatherDisappear()
    {
        yield return new WaitForSeconds(1);
        CallFadeIn();
        Invoke(nameof(DisableFather), 1f);
    }


    public void FadeAndFatherDisappear()
    {
        *//*        CallFadeIn();
                Invoke(nameof(DisableFather), 1f);*//*
        StartCoroutine(WaitFadeAndFatherDisappear());
    }

    public void DisableFather()
    {
        father.SetActive(false);
        block.SetActive(false);
        CallFadeOut();
    }

*//*    public void FadeCutscene()
    {
        fader.DoFadeIn();
        Invoke(nameof(FadeSecond), 1f);

        Debug.Log("2");
    }*//*

    public void FadeSecond()
    {
        CallFadeOut();
        Debug.Log("1");

    }
}
*/
{
    public GameObject father;
    public GameObject block;
    public ScreenFader fader; // the screen fader on the center eye camera, drag the camera here

    public void CallFadeIn()
    {
        fader.DoFadeIn();
    }

    public void CallFadeOut()
    {
        fader.DoFadeOut();
    }

    IEnumerator WaitFadeAndFatherDisappear()
    {
        yield return new WaitForSeconds(4);
        CallFadeIn();
        StartCoroutine(DisableFatherAfterDelay());
    }

    public void FadeAndFatherDisappear()
    {
        StartCoroutine(WaitFadeAndFatherDisappear());
    }

    IEnumerator DisableFatherAfterDelay()
    {
        // Wait for a few seconds before deactivating the father GameObject
        yield return new WaitForSeconds(1);

        father.SetActive(false);
        block.SetActive(false);
        CallFadeOut();
    }

    public void FadeSecond()
    {
        CallFadeOut();
        Debug.Log("1");
    }
}
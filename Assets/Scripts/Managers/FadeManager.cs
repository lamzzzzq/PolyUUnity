using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public FadeWithinScene fadeWithinScene;
    public Animator animator;

    public IEnumerator DoFadeIn()
    {
        yield return StartCoroutine(fadeWithinScene.FadeIn());
    }

    public IEnumerator DoFadeOut()
    {
        yield return StartCoroutine(fadeWithinScene.FadeOut());
    }

    public void FadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(DoFadeOut());
    }

    

}

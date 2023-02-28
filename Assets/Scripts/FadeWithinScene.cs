using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWithinScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public void Fade()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        animator.SetBool("FadeOut", true);
        animator.SetBool("FadeIn", false);

        //Calculate the duration of the fade-out animation 
        float fadeOutDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(fadeOutDuration);
    }
}

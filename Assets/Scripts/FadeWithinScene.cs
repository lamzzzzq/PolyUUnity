using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWithinScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    private void Start()
    {
        
    }

    public void Fade()
    {
        StartCoroutine(FadeIn());
        
    }


    IEnumerator FadeIn()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        animator.SetBool("FadeOut", true);
        animator.SetBool("FadeIn", false);
        yield return null;
    }


}

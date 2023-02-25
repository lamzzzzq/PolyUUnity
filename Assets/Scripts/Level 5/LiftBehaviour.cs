using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LiftBehaviour : MonoBehaviour
{
    public bool isDoorOpened = false;
    public bool isAudioPlayed = false;
    public Animator doorAnimator;
    public AudioSource LiftPersonAudio;
    public GameObject liftPerson;
    public GameObject player;
    public GameObject targetPosition;
    public FadeManager fadeManager;
    public Animator fadeAnim;

    private bool _hasCompletedLiftFlow = false;

    public void OpenLiftDoor()
    {
        if (!isDoorOpened)
        {
            doorAnimator.Play("Open");
            Debug.Log("Animation Played");
            isDoorOpened = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SubPlayer" && !_hasCompletedLiftFlow)
        {
            StartCoroutine(LiftFlow());
        }
    }

    IEnumerator LiftFlow()
    {
        yield return new WaitForSeconds(1);
        PlayAudio();
        yield return new WaitForSeconds(0.5f);
        ShowConversation();
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<LiftPerson>().WalkTowardTheLift();
        _hasCompletedLiftFlow = true;
    }

    public void PlayAudio()
    {
        if (!isAudioPlayed)
        {
            LiftPersonAudio.Play();
            isAudioPlayed = true;
        }
    }

    public void ShowConversation()
    {
        liftPerson.GetComponent<DialogueSystemTrigger>().OnUse();
    }


    public void TeleportPlayerWithFade()
    {
        //StartCoroutine(TeleportPlayerWithFadeCoroutine());
        StartCoroutine(teleportaion());
    }

    IEnumerator TeleportPlayerWithFadeCoroutine()
    {
        // Fade in
        yield return StartCoroutine(FadeIn());

        // Fade out
        yield return StartCoroutine(FadeOut());
    }

    IEnumerator teleportaion()
    {
        
        player.transform.position = targetPosition.transform.position;
        yield return new WaitForSeconds(2f);
    }


    IEnumerator FadeIn()
    {
        fadeAnim.SetBool("FadeIn", true);
        fadeAnim.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator FadeOut()
    {
        fadeAnim.SetBool("FadeOut", true);
        fadeAnim.SetBool("FadeIn", false);
        float fadeOutDuration = fadeAnim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(fadeOutDuration);
    }

}

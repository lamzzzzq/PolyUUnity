using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;
using UnityEngine.Events;

public class LiftBehaviour : MonoBehaviour
{
    public bool isDoorOpened = false;
    public bool isDoorClosed = false;
    public bool isAudioPlayed = false;
    public bool isAudioPersonPlayed = false;
    public Vector3 rotationDegree_1;
    public Animator doorAnimator;
    public AudioSource liftMenuAudio;
    public GameObject liftPerson;
    public GameObject canvas;

    private TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public CharacterController playerController;

    public GameObject player;
    public GameObject targetPosition;
    private bool isCoroutineRunning = false;

    public UnityEvent npcEvents;


    public AudioSource liftAudioSource;
    public AudioClip liftAudioClip;



    //public FadeManager fadeManager;
    public Animator fadeAnim;
    //public PlayerTeleport Teleport;

    private bool _hasCompletedLiftFlow = false;
    private void Start()
    {
        teleport = player.GetComponent<TeleportPlayerFade>();
    }

    public void OpenLiftDoor()
    {
        if (!isDoorOpened)
        {
            doorAnimator.Play("Open");
            Debug.Log("Animation Played");
            isDoorOpened = true;
        }
    }

/*    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SubPlayer" && !_hasCompletedLiftFlow)
        {
            StartCoroutine(LiftFlow());
        }
    }*/
    public void StartLift()
    {
        if(!_hasCompletedLiftFlow)
        {
            StartCoroutine(LiftFlow());
        }
    }


    IEnumerator LiftFlow()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<LiftPerson>().WalkTowardTheLift();
        PlayLiftPersonAudio();
        yield return new WaitForSeconds(liftAudioClip.length);
        PlayAudio();
        yield return new WaitForSeconds(0.5f);
        ShowConversation();
        _hasCompletedLiftFlow = true;
    }

    public void PlayAudio()
    {
        if (!isAudioPlayed)
        {
            liftMenuAudio.Play();
            isAudioPlayed = true;
        }
    }

    public void PlayLiftPersonAudio()
    {
        if (!isAudioPersonPlayed)
        {
            liftAudioSource.PlayOneShot(liftAudioClip);
            isAudioPersonPlayed = true;
        }
    }

    public void ShowConversation()
    {
        //liftPerson.GetComponent<DialogueSystemTrigger>().OnUse();

        canvas.SetActive(true);
    }


    public void TeleportPlayerWithFade()
    {
        //StartCoroutine(TeleportPlayerWithFadeCoroutine());
        Debug.Log(targetPosition.transform.position);
        player.transform.position = targetPosition.transform.position;
        //player.GetComponent<CharacterController>().enabled = true;
    }

/*    IEnumerator TeleportPlayerWithFadeCoroutine()
    {
        // Fade in
        yield return StartCoroutine(FadeIn());

        // Fade out
        yield return StartCoroutine(FadeOut());
    }
*/
    IEnumerator teleportaion()
    {
        Debug.Log("KK");
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

    public void CloseLiftDoor()
    {
        if (!isDoorClosed && !isCoroutineRunning)
        {
            Debug.Log("yes closeliftdoor event executed.");

            StartCoroutine(CloseLift());
        }
    }

    IEnumerator CloseLift()
    {
        isCoroutineRunning = true;

        yield return new WaitForSeconds(5f);

        //Play countdown UI


        doorAnimator.Play("Close");
        playerController.enabled = false;
        Debug.Log("Animation Close Played");
        isDoorClosed = true;
        teleport.ResetPlayerPosRotWithParameters(targetPosition.transform, ScreenFader);
        yield return new WaitForSeconds(2f);
        playerController.enabled = true;

        isCoroutineRunning = false;
    }

    public void StopDoorCloseCoroutine()
    {
        StopAllCoroutines();
    }

    public void Test()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(player.transform, ScreenFader);
    }

    public void CloseLiftDoorWhenSuccess()
    {
        if (!isDoorClosed)
        {
            Debug.Log("yes closeliftdoor event executed.");

            StartCoroutine(CloseLiftWhenSuccess());
        }
    }

    IEnumerator CloseLiftWhenSuccess()
    {
        yield return new WaitForSeconds(2f);

        //Play countdown UI


        doorAnimator.Play("Close");
        playerController.enabled = false;
        Debug.Log("Animation Close Played");
        isDoorClosed = true;
        teleport.ResetPlayerPosRotWithParameters(targetPosition.transform, ScreenFader);
        yield return new WaitForSeconds(2f);
        playerController.enabled = true;
    }

    public void YesCoroutine()
    {
        //quest status change to Active
        QuestLog.SetQuestState("HoldLift", QuestState.Active);
        //envoke event : LiftBehaviour.CloseLiftDoor
        npcEvents.Invoke();
    }

    public void NoCoroutine()
    {
        //quest status change to failure
        QuestLog.SetQuestState("HoldLift", QuestState.Failure);
        //envoke event : LiftBehaviour.CloseLiftDoor
        npcEvents.Invoke();
    }

}

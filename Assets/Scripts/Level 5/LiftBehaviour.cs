using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class LiftBehaviour : MonoBehaviour
{
    public bool isDoorOpened = false;
    public bool isDoorClosed = false;
    public bool isAudioPlayed = false;
    public Vector3 rotationDegree_1;
    public Animator doorAnimator;
    public AudioSource LiftPersonAudio;
    public GameObject liftPerson;

    private TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public PlayerController playerController;

    public GameObject player;
    public GameObject targetPosition;
    


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
        if (!isDoorClosed)
        {
            Debug.Log("yes closeliftdoor event executed.");
            playerController.enabled = false;
            StartCoroutine(CloseLift());
        }
    }

    IEnumerator CloseLift()
    {
        yield return new WaitForSeconds(5f);

        //Play countdown UI


        doorAnimator.Play("Close");
        Debug.Log("Animation Close Played");
        isDoorClosed = true;
        //Fix Later: Face direction after teleportation
        teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(targetPosition.transform, ScreenFader);
    }

    public void StopDoorCloseCoroutine()
    {
        StopAllCoroutines();
    }

    public void Test()
    {
        teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(player.transform, ScreenFader);
    }

}

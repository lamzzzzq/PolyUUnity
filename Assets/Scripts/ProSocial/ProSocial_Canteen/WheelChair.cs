using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;
using UnityEngine.AI;
using UnityEngine.Events;

public class WheelChair : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Animator _anim;
    public bool walk = false;
    public AudioSource canvasAudioSource;
    public AudioClip canvasAudioClip;

    public Transform targetPosition;
    public float WalkValue;
    public float StopValue;

    public GameObject wheechairCanvas;

    private bool audioPlayed = false;

    public FacePlayerNormal facePlayer;
    public GameObject pan;

    private void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (walk)
        {
            if (Vector3.Distance(transform.position, targetPosition.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Move", true);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Move", false);

                if (!audioPlayed)
                {
                    //Play audio clip
                    canvasAudioSource.PlayOneShot(canvasAudioClip);
                    wheechairCanvas.SetActive(true);
                    _agent.enabled = false;
                    targetPosition = transform;
                    pan.SetActive(true);
                    //_agent.SetDestination(transform.position);
                    StartCoroutine(PlayAudioAndEnableButton());

                    audioPlayed = true;
                }
            }
        }

    }


    public void NPCTalk()
    {
        faceOurPlayer();
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void moveToDestination()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
    }

    public void faceOurPlayer()
    {
        facePlayer.enabled = true;
    }


    private IEnumerator PlayAudioAndEnableButton()
    {
        yield return new WaitForSeconds(canvasAudioClip.length);
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = wheechairCanvas.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

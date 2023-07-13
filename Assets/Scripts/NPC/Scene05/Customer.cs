using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Animator _anim;
    public float WalkValue;
    public float StopValue;
    public bool walk = false;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private FacePlayerNormal facePlayer;

    public UnityEvent knockDownEvent;

    public Transform targetPosition;

    public WheelChairTaskOnPlayer wheelChairOnPlayer;


    public GameObject wheechairCanvas1;
    public GameObject wheechairCanvas2;

    private bool audioPlayed = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        facePlayer = GetComponent<FacePlayerNormal>();
    }

    private void Update()
    {
        if(walk)
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
                facePlayer.enabled = true;

                if(wheelChairOnPlayer.triggerLeft)
                {
                    if(!audioPlayed)
                    {
                        //Play audio clip
                        audioSource.PlayOneShot(audioClip);
                        wheechairCanvas1.SetActive(true);
                        StartCoroutine(PlayAudioAndEnableButton_1());

                        audioPlayed = true;
                    }    
                }
                else
                {
                    if(!audioPlayed)
                    {
                        //Play audio clip
                        audioSource.PlayOneShot(audioClip);
                        wheechairCanvas2.SetActive(true);
                        StartCoroutine(PlayAudioAndEnableButton_2());
                        audioPlayed = true;
                    }

                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            Debug.Log("Drop!");
            knockDownEvent.Invoke();
        }
    }

    public void WalkTowardTarget()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
    }

    private IEnumerator PlayAudioAndEnableButton_1()
    {
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable_1(true);
    }

    private void SetButtonsInteractable_1(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = wheechairCanvas1.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }

    private IEnumerator PlayAudioAndEnableButton_2()
    {
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable_2(true);
    }

    private void SetButtonsInteractable_2(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = wheechairCanvas2.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

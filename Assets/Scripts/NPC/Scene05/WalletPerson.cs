using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;
using BNG;

public class WalletPerson : MonoBehaviour
{
    public float WalkValue;
    public float StopValue;
    public Transform targetPosition;
    public GameObject phone;
    public GameObject phoneCanvas;
    public List<GameObject> customer;
    public GameObject phonePersonToActive;

    public AudioClip audioClip;
    public AudioSource audioSource;

    public GameObject player;

    private NavMeshAgent _agent;
    private Animator _anim;
    //public FacePlayerNormal facePlayer;
    private Transform target;
    private bool activatePhone;
    private bool secondNav = false;

    public GameObject ObjectToCreate;

    private bool audioPlayed = false;



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        activatePhone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
                //facePlayer.enabled = false;
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
                //facePlayer.enabled = true;
                if (!activatePhone)
                {
                    phone.SetActive(true);
                    activatePhone = true;
                }

                StartCoroutine(SetActiveCanvas());

                foreach (var item in customer)
                {
                    item.SetActive(false);
                }

                target = transform;
                _agent.isStopped = true;
                transform.position = new Vector3(-7.9f, -50f, -134.85f);




                //切换canvas
                //this.GetComponent<OverrideDialogueUI>().ui = GameObject.Find(childUIName);
                //和玩家对话
                //this.GetComponent<DialogueSystemTrigger>().OnUse();
                //secondNav = true;
                //secondNav = true;
                
                //this.GetComponent<DialogueSystemTrigger>().OnUse();
            }
        }
    }



    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }

    private IEnumerator SetActiveCanvas()
    {
        yield return new WaitForSeconds(2);
        phoneCanvas.SetActive(true);
        if (!audioPlayed)
        {
            //Play audio clip
            audioSource.PlayOneShot(audioClip);
            phonePersonToActive.SetActive(true);
            StartCoroutine(PlayAudioAndEnableButton());
            audioPlayed = true;
        }
    }

    public void ReleasePhone()
    {
        phone.GetComponent<Grabbable>().CanBeDropped = true;

        phone.SetActive(false);
    }

    public void WalkToPlayer()
    {
        target = player.transform;
    }

    private IEnumerator PlayAudioAndEnableButton()
    {
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = phonePersonToActive.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

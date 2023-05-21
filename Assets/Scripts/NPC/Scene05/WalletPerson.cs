using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class WalletPerson : MonoBehaviour
{
    public float WalkValue;
    public float StopValue;
    public Transform targetPosition;
    public GameObject phone;
    public GameObject phoneCanvas;

    private NavMeshAgent _agent;
    private Animator _anim;
    //public FacePlayerNormal facePlayer;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
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

                phone.SetActive(true);
                phoneCanvas.SetActive(true);
                //�л�canvas
                //this.GetComponent<OverrideDialogueUI>().ui = GameObject.Find(childUIName);
                //����ҶԻ�
                //this.GetComponent<DialogueSystemTrigger>().OnUse();
            }
        }
    }



    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }
}

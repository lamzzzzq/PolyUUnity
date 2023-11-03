using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;


public class Library_LiftNPC : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    public FacePlayerNormal facePlayer;
    private Transform target;
    public float WalkValue;
    public float StopValue;
    public Transform targetPosition;

    public bool isTalk = false;


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
                facePlayer.enabled = false;
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
                facePlayer.enabled = true;

                //切换canvas
                //this.GetComponent<OverrideDialogueUI>().ui = GameObject.Find(childUIName);
                //和玩家对话
                if (!isTalk)
                {
                    this.GetComponent<DialogueSystemTrigger>().OnUse();
                    isTalk = true;
                }

            }
        }
    }

    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }

}

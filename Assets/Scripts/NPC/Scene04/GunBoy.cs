using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;
public class GunBoy : MonoBehaviour
{
    public Transform target;
    private Transform towardPlayerTarget;
    public FacePlayerNormal facePlayer;
    public float WalkValue;
    public float StopValue;
    public Transform OnJetTarget;

    public Transform walkAwayTarget;

    private NavMeshAgent _agent;
    private Animator _anim;

    private void Start()
    {
        towardPlayerTarget = target;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*        bool agree = DialogueLua.GetVariable("TASK_4_2_AGREE").asBool;
                if (agree == true)
                {
                    _agent.isStopped = true;
                    transform.position = OnJetTarget.position;
                }*/
        _agent.SetDestination(target.transform.position);
        if (Vector3.Distance(transform.position, target.position) > WalkValue)
        {
            //Debug.Log("I am walking");
            _agent.isStopped = false;
            _anim.SetBool("Walk", true);
            facePlayer.enabled = false;
        }

        if (Vector3.Distance(transform.position, target.position) < StopValue)
        {
            //Debug.Log("I am stop");
            _agent.isStopped = true;
            _anim.SetBool("Walk", false);
            _anim.SetBool("Fall", false);
            //GunBoyTalking.Invoke();
            facePlayer.enabled = true;
        }
    
    }


    public void OnJet()
    {
        transform.position = OnJetTarget.position;
        transform.rotation = Quaternion.Euler(0, 2.5f, 0);

        _anim.SetTrigger("Drive");

    }

    public void WalkAway()
    {
        _agent.isStopped = false;
        target = walkAwayTarget;
        _agent.SetDestination(target.transform.position);
    }

    public void WalkToPlayer()
    {
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);
    }

    public void WalkToPlayerSecond()
    {
        target = towardPlayerTarget;
        _agent.isStopped = false;
        
    }

}
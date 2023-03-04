using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LiftPerson : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    private Transform target;
    public Transform targetPosition;
    public float WalkValue;
    public float StopValue;

    public Transform LiftTargetPosition;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
            }
        }

    }


    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }

    public void WalkIntoTheLift()
    {
        Debug.Log("Hi");
        target = LiftTargetPosition;
        _agent.SetDestination(target.position);
    }
}

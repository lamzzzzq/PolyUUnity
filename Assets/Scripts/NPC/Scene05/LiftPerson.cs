using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LiftPerson : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public LiftButton liftButton;
    public Transform targetPosition;

    public Transform LiftTargetPosition;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }


    public void WalkTowardTheLift()
    {
        _agent.SetDestination(targetPosition.position);
    }

    public void WalkIntoTheLift()
    {
        _agent.SetDestination(LiftTargetPosition.position);
    }
}

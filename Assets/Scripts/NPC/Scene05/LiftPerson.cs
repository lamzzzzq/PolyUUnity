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

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(liftButton.isTriggerActive == true)
        {
            StartCoroutine(WalkTowardTheLift());
        }
    }

    IEnumerator WalkTowardTheLift()
    {
        _agent.SetDestination(targetPosition.position);
        yield return new WaitForSeconds(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Animator _anim;
    public float WalkValue;
    public float StopValue;
    public bool walk = false;

    public Transform targetPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(walk)
        {
            if (Vector3.Distance(transform.position, targetPosition.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
            }
        }

    }

    public void WalkTowardTarget()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
        ItemDrop();
    }

    public void ItemDrop()
    {
        Debug.Log("Drop!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayClassmates : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform targetPosition;
    public float walkValue, stopValue;


    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();
        moveOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition.transform.position) > walkValue)
        {
            _agent.isStopped = false;
            isWalk();
        }
    }



    private void isWalk()
    {
        _anim.SetBool("isWalk", true);
        _anim.SetBool("isTalk", false);
    }

    public void moveOut()
    {
        _agent.SetDestination(targetPosition.position);
        Debug.Log("Moving to classmate at position: " + targetPosition.position);
    }

}

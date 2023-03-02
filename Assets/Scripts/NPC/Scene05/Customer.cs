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

    private FacePlayerNormal facePlayer;

    public UnityEvent knockDownEvent;

    public Transform targetPosition;

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
                _anim.SetBool("Walk", true);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < StopValue)
            {
                knockDownEvent.Invoke();
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
                facePlayer.enabled = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //knockDownEvent.Invoke();
        //还是没做好，timeslot的问题，不知道为什么other.tag检测不了

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

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

    public WheelChairTaskOnPlayer wheelChairOnPlayer;


    public GameObject wheechairCanvas1;
    public GameObject wheechairCanvas2;

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
                _anim.SetBool("Move", true);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Move", false);
                facePlayer.enabled = true;

                if(wheelChairOnPlayer.triggerLeft)
                {
                    wheechairCanvas1.SetActive(true);
                }
                else
                {
                    wheechairCanvas2.SetActive(true);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            Debug.Log("Drop!");
            knockDownEvent.Invoke();
        }
    }

    public void WalkTowardTarget()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
    }
}

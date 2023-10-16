using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayNPC : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Animator _anim;
    public bool walk = false;
    public Transform targetPosition;

    public float WalkValue;
    public float StopValue;

    // Start is called before the first frame update
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
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
            }
        }
    }

    public void moveToDestination()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
    }
}

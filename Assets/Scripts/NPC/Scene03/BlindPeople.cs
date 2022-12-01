using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlindPeople : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform Target;
    

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) < 0.5f)
        {
            //Debug.Log("Hey0");
            _agent.isStopped = true;

            //Debug.Log("Hey1");
            _anim.SetBool("Idle", true);
            _anim.SetBool("Walk", false);
            //Debug.Log("Hey2");
        }

    }
    //从外部call这个function 只执行一次
    public void WalkTowardTheDestination()
    {
        _agent.isStopped = false;
        _agent.SetDestination(Target.transform.position);
        _anim.SetBool("Walk", true);
        _anim.SetBool("Idle", false);
    }
}

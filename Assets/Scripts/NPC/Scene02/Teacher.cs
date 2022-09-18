using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform Target;

    public bool isArrived = false;



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isArrived)
        {
            _agent.SetDestination(Target.transform.position);
            //.SetTrigger("Walking");
            Debug.Log("里面执行一次");
        }
        Debug.Log("外面执行一次");


/*        if (Vector3.Distance(transform.position, Target.position)< 0.2f)
        {
            isArrived = true;
            _anim.SetTrigger("Idle");
        }*/
    }


    public void WalkTowardTheDoor() 
    {
/*        if(!isArrived)
        {
            _agent.transform.position = Target.transform.position;
            _anim.SetTrigger("Walking");
            Debug.Log("里面执行一次");
        }
        Debug.Log("外面执行一次");*/
    }

}

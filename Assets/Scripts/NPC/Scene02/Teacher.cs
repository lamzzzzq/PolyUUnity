using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform Target;

    public FacePlayer faceplayer;




    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("isTripping", false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.position)< 0.1f)
        {
            _agent.isStopped = true;
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isTripping", true);

            StartCoroutine(TurnAround(5.0f));

            //_anim.SetBool("isSad", true);
            //faceplayer.enabled = true;
        }
    }


    public void WalkTowardTheDoor() 
    {
         _agent.SetDestination(Target.transform.position);
         _anim.SetBool("isWalking",true);
            
    }


    private IEnumerator TurnAround(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        faceplayer.enabled = true;
        _anim.SetBool("isSad", true);
    }

}

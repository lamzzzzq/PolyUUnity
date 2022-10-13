using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform Target1;
    public Transform Target2;
    Transform Target;

    bool Fall;

    public FacePlayer faceplayer;





    // Start is called before the first frame update
    void Start()
    {
        Target = Target1;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("Fall", false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.position)< 0.1f && Fall == true) 
        {
            _agent.isStopped = true;
            _anim.SetBool("Walk", false);
            _anim.SetBool("Fall", true);

            StartCoroutine(GoToTheSecondPoint(3f));           //写在这里？？
            Debug.Log("first");

            //_anim.SetBool("isSad", true);
            //faceplayer.enabled = true;
        }
        if (Vector3.Distance(transform.position, Target.position) < 0.1f && Fall == false)
        {
            _anim.SetBool("Walk", false);
            _agent.isStopped = true;
            StartCoroutine(Delay(10f));
            faceplayer.enabled = true;
            Debug.Log("second");
        }
    }

    //从外部call这个function 只执行一次
    public void WalkTowardTheDoor() 
    {
        _agent.isStopped = false;
        _agent.SetDestination(Target.transform.position);
        _anim.SetBool("Walk",true);
        _anim.SetBool("Fall", false);
        Fall = true;
    }


    private IEnumerator GoToTheSecondPoint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Target = Target2;
        _agent.SetDestination(Target.transform.position);
        _agent.isStopped = false;
        _anim.SetBool("Walk", true);
        _anim.SetBool("Fall", false);
        Fall = false;

        //faceplayer.enabled = true;
        //_anim.SetBool("Wave", true);

    }

    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    /*    public void StopWave()
        {
            _anim.SetBool("Wave", false);
            _anim.SetBool("Fall", false);
        }*/

}

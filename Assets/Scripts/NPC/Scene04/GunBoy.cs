using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class GunBoy : MonoBehaviour
{
    public Transform target;
    public FacePlayer facePlayer;
    public float WalkValue;
    public float StopValue;
    public UnityEvent GunBoyTalking;

    public Transform walkAwayTarget;

    private NavMeshAgent _agent;
    private Animator _anim;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _agent.SetDestination(target.transform.position);
        if (Vector3.Distance(transform.position, target.position) > WalkValue)
        {
            Debug.Log("I am walking");
            _agent.isStopped = false;
            _anim.SetBool("Walk", true);
            facePlayer.enabled = false;
        }

        if (Vector3.Distance(transform.position, target.position) < StopValue)
        {
            Debug.Log("I am stop");
            _agent.isStopped = true;
            _anim.SetBool("Walk", false);
            _anim.SetBool("Fall", false);
            GunBoyTalking.Invoke();
            facePlayer.enabled = true;

        }
    }


    public void OnJet()
    {
        transform.position = new Vector3(0.6f, -0.07f, -149f);
        transform.rotation = Quaternion.Euler(0, 2.5f, 0);
    }

    public void WalkAway()
    {
        target = walkAwayTarget;
        _agent.SetDestination(target.transform.position);
    }
}
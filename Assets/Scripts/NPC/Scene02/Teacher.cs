using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform _target;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _target.transform.position;
    }
}

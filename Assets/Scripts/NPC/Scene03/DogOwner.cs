using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class DogOwner : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    public Transform targetNPC;
    public Transform targetDog;
    private Transform target;

    public FacePlayerNormal facePlayer;

    public float WalkValue;
    public float StopValue;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        target = targetNPC;

    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(target.transform.position);

        if (Vector3.Distance(transform.position,target.position)>WalkValue)
        {
            Debug.Log("I am walking");
            _agent.isStopped = false;
            _anim.SetBool("Walk", true);
            facePlayer.enabled = false;
        }

        if(Vector3.Distance(transform.position,target.position)<StopValue)
        {
            Debug.Log("I am stop");
            _agent.isStopped = true;
            _anim.SetBool("Walk", false);
            _anim.SetBool("Fall", false);

            facePlayer.enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            DialogueLua.SetVariable("TASK_3_4_ARRIVE", true);
            target = targetDog;
            Debug.Log("CHANGE TARGET TO DOG");
        }
    }


}

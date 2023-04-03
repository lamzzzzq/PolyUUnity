using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform Target1;
    public Transform Target2;
    Transform Target;

    public GameObject npc;

    bool Fall;

    public FacePlayer faceplayer;

    void Start()
    {
        Target = Target1;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("Fall", false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) < 0.1f && Fall == true)
        {
            StopMoving();
            _anim.SetBool("Fall", true);
            StartCoroutine(GoToTheSecondPoint(3f));
        }
        if (Vector3.Distance(transform.position, Target.position) < 0.1f && Fall == false)
        {
            StopMoving();
            StartCoroutine(Delay(10f));
            faceplayer.enabled = true;
        }
    }

    // Stop the NPC and update the animation state
    private void StopMoving()
    {
        _agent.isStopped = true;
        _anim.SetBool("Walk", false);
    }

    public void WalkTowardTheDoor()
    {
        _agent.isStopped = false;
        _agent.SetDestination(Target.transform.position);
        _anim.SetBool("Walk", true);
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
    }

    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _anim.SetBool("Walk", false); // Ensure Walk is set to false after the delay
    }

    public void TeacherGreeting()
    {
        //PixelCrushers.QuestMachine.QuestGiver.Start

        foreach (var trigger in npc.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}

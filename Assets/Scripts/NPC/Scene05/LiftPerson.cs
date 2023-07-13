using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class LiftPerson : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    public FacePlayerNormal facePlayer;
    private Transform target;
    public Transform targetPosition;
    public float WalkValue;
    public float StopValue;

    public string childUIName = "LiftPersonDialogueUI";


    public Transform LiftTargetPosition;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
                facePlayer.enabled = false;
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
                facePlayer.enabled = true;

                //切换canvas
                //this.GetComponent<OverrideDialogueUI>().ui = GameObject.Find(childUIName);
                //和玩家对话
                this.GetComponent<DialogueSystemTrigger>().OnUse();
            }
        }

    }


    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }

    public void WalkIntoTheLift()
    {
        StartCoroutine(WaitAndWalkIntoTheLift());
    }

    private IEnumerator WaitAndWalkIntoTheLift()
    {
        yield return new WaitForSeconds(0.5f); // wait for 0.5 seconds
        _agent.isStopped = false;
        target = LiftTargetPosition;
        _agent.SetDestination(target.position);
        QuestLog.SetQuestState("HoldLift", QuestState.Success);
    }
}

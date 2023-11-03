using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;
public class GunBoy : MonoBehaviour
{
    private Transform target;
    public Transform targetPosition;
    public FacePlayerNormal facePlayer;
    public float WalkValue;
    public float StopValue;
    public Transform OnJetTarget;

    public Transform walkAwayTarget;

    private NavMeshAgent _agent;
    private Animator _anim;
    private EnemyController _enemyController;
    private bool faceNPC = false;


    public GameObject npcFaceTarget;
    public DecrementScript bubbleScript;
    public BubbleCarOnPlayer bubbleCarLogic;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        /*        bool agree = DialogueLua.GetVariable("TASK_4_2_AGREE").asBool;
                if (agree == true)
                {
                    _agent.isStopped = true;
                    transform.position = OnJetTarget.position;
                }*/

        /*        if (Vector3.Distance(transform.position, target.position) > WalkValue)
                {
                    //Debug.Log("I am walking");
                    _agent.isStopped = false;
                    _anim.SetBool("Walk", true);
                    facePlayer.enabled = false;
                }

                if (Vector3.Distance(transform.position, target.position) < StopValue)
                {
                    //Debug.Log("I am stop");
                    _agent.isStopped = true;
                    _anim.SetBool("Walk", false);
                    _anim.SetBool("Fall", false);
                    //GunBoyTalking.Invoke();
                    facePlayer.enabled = true;
                }*/

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

                if(!faceNPC)
                {
                    bubbleCarLogic.faceNPC();
                    faceNPC = true;
                }

                foreach (var item in this.GetComponents<DialogueSystemTrigger>())
                {
                    item.OnUse();
                }
            }
        }

    }


    public void OnJet()
    {
        target = OnJetTarget;
        _agent.isStopped = true;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<FacePlayerNormal>().player = npcFaceTarget.transform;
        transform.position = OnJetTarget.position;
        transform.rotation = Quaternion.Euler(0, 2.5f, 0);

        _anim.SetTrigger("Drive");

    }
    
    public void WalkAway()
    {
        target = walkAwayTarget;
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);
    }

    public void TeleportNPC()
    {
        canCount();
        target = null;
        _agent.isStopped = true;
        transform.position = walkAwayTarget.position;

    }

    public void WalkToPlayer()
    {
        cantCount();
        _enemyController.enabled = false;
        target = targetPosition;
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);
        Debug.Log("Walk to player");
    }

    public void WalkToPlayerSecond()
    {
        cantCount();
        target = targetPosition;
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);
    }

    public void canCount()
    {
        bubbleScript.isNPCMoving = false;
    }

    public void cantCount()
    {
        bubbleScript.isNPCMoving = true;
    }

}
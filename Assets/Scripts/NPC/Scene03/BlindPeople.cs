using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;

public class BlindPeople : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    //public AudioSource _audio;
    public Transform Target1;
    public Transform Target2;
    public GameObject Block;
    public GameObject BlockNewRoad;

    public FacePlayerNormal facePlayer;

    public UnityAction onTargetReached;

    Transform target;

    private bool TASK_3_2_DONE;
    private bool Task_3_2_help;
    private bool hasStartedWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        target = Target1;
    }

    // Update is called once per frame
    void Update()
    {
 
        Task_3_2_help = DialogueLua.GetVariable("TASK_3_2_HELP").asBool;

        if (Task_3_2_help && !hasStartedWalking)
        {
            Debug.Log("Heihei!");
            hasStartedWalking = true;
            NotFacePlayer();
            WalkCrossTheRoadFunction();
            // Add the following line to set the callback function:
            onTargetReached += TriggerNewConversation;
            //Switch the state
        }

        //Debug.Log(Task_3_2_help + "Update");
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            _agent.isStopped = true;
            _anim.SetBool("Idle", true);
            _anim.SetBool("Walk", false);

            onTargetReached?.Invoke();
            onTargetReached = null; // Reset the callback to avoid triggering again.
        }



        
    }
    //从外部call这个function 只执行一次
    public void WalkTowardTheDestination()
    {
        target = Target1;
        _agent.isStopped = false;
        _agent.SetDestination(target.transform.position);
        _anim.SetBool("Walk", true);
        _anim.SetBool("Idle", false);
    }

    public void PlaceItem()
    {
        DialogueLua.SetVariable("CleanDebris", true);

    }

    IEnumerator WalkCrossTheRoad()
    {
        target = Target2;
        yield return new WaitForSeconds(2);
        Block.SetActive(false);
        _agent.SetDestination(target.transform.position);
        _agent.isStopped = false;
        _anim.SetBool("Walk",true);
        _anim.SetBool("Idle", false);
        BlockNewRoad.SetActive(false);

        //DialogueLua.SetVariable("TASK_3_2_HELP", false);
    }

    public void WalkCrossTheRoadFunction()
    {
        target = Target2;
        Block.SetActive(false);
        _agent.SetDestination(target.transform.position);
        _agent.isStopped = false;
        _anim.SetBool("Walk", true);
        _anim.SetBool("Idle", false);
        BlockNewRoad.SetActive(false);
    }

    void TriggerNewConversation()
    {

        DialogueLua.SetVariable("TASK_3_2_DONE", true);
    }

    public void NotFacePlayer()
    {
        facePlayer.enabled = false;
    }
}

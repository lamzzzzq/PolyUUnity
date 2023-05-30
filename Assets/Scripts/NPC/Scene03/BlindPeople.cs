using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;
using BNG;

public class BlindPeople : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    //public AudioSource _audio;
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform PlayerPosition;
    public GameObject Block;
    public Vector3 rotation;
    //public GameObject BlockNewRoad;
    public GameObject blindPerson;

    public FacePlayerNormal facePlayer;

    public UnityAction onTargetReached;

    Transform target;

    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public Transform playerPosition;

    private bool TASK_3_2_DONE;
    private bool Task_3_2_help;
    private bool hasStartedWalking = false;

    private bool hasTouch = false;


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

        // 5.15 comment
        /*Task_3_2_help = DialogueLua.GetVariable("TASK_3_2_HELP").asBool;

        if (Task_3_2_help && !hasStartedWalking)
        {
            Debug.Log("Heihei!");
            hasStartedWalking = true;
            NotFacePlayer();
            WalkCrossTheRoadFunction();
            // Add the following line to set the callback function:
            onTargetReached += TriggerNewConversation;
            //Switch the state
        }*/

        //Debug.Log(Task_3_2_help + "Update");
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            _agent.isStopped = true;
            _anim.SetBool("Idle", true);
            _anim.SetBool("Walk", false);

            facePlayer.enabled = true;
            // 5.15 comment
            /*onTargetReached?.Invoke();
            onTargetReached = null; // Reset the callback to avoid triggering again.*/
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
        ShowBlindPersonConversation();

    }

    public void PlaceItem()
    {
        DialogueLua.SetVariable("CleanDebris", true);
    }

    public void WalkCrossTheRoadFunction()
    {
        target = Target2;
        Block.SetActive(false);
        _agent.SetDestination(target.transform.position);
        _agent.isStopped = false;
        _anim.SetBool("Walk", true);
        _anim.SetBool("Idle", false);
        //BlockNewRoad.SetActive(false);
    }

    void TriggerNewConversation()
    {

        DialogueLua.SetVariable("TASK_3_2_DONE", true);
    }

    public void NotFacePlayer()
    {
        facePlayer.enabled = false;
    }

    public void ShowBlindPersonConversation()
    {
        foreach (var trigger in GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }

    public void TeleportAndFadeAfterTouch()
    {
        if (!hasTouch)
        {
            StartCoroutine(TouchAndHelp());
        }
        hasTouch = true;
    }

    private IEnumerator TouchAndHelp()
    {
        this.transform.position = Target3.position;

        //teleport.targetRotation = Quaternion.Euler(rotation) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);
        TriggerNewConversation();
        yield return new WaitForSeconds(1f);
        
        ShowBlindPersonConversation();
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class BallonGirl : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public FacePlayerNormal facePlayer;
    public float WalkValue;
    public float StopValue;

    public bool firstTimeArrive = false;
    public bool secondTimeArrive = false;
    public GameObject canvas;

    public LegoOnPlayer legoOnPlayer;


    private NavMeshAgent _agent;
    private Animator _anim;

    private bool showCanvas = false;

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
            _anim.SetBool("Run", true);
            facePlayer.enabled = false;
        }

        if (Vector3.Distance(transform.position, target.position) < StopValue)
        {
            Debug.Log("I am stop");
            _agent.isStopped = true;
            _anim.SetBool("Run", false);
            _anim.SetBool("Fall", false);

            facePlayer.enabled = true;

            if(!firstTimeArrive)
            {
                Debug.Log("firstTime is true");
                if (!showCanvas)
                {
                    Debug.Log("firstTime is true - Once");
                    canvas.SetActive(true);
                    showCanvas = true;
                    firstTimeArrive = true;
                }
            }
        }

/*        if (!secondTimeArrive && firstTimeArrive && Vector3.Distance(transform.position, target2.position) < StopValue)
        {
            Debug.Log("Second destination reached");

            foreach (var item in this.GetComponents<DialogueSystemTrigger>())
            {
                item.OnUse();
            }

            secondTimeArrive = true;
        }*/
    }
    public void GetBallon()
    {
        //DialogueLua.SetVariable("TASK_4_4_ARRIVE", true);

        //QuestLog.SetQuestEntryState("Get the Balloon", 1, QuestState.Success);

        QuestLog.SetQuestState("Get the Balloon", QuestState.Success);
    }

    public void SecondDestination()
    {
        StartCoroutine(WatiForConversationEnd());
    }

    private IEnumerator WatiForConversationEnd()
    {
        yield return new WaitForSeconds(2);
        target = target2;
        yield return new WaitForSeconds(3);
        legoOnPlayer.playerController.enabled = true;
    }

    public void EnableController()
    {
        legoOnPlayer.playerController.enabled = true;
    }
}

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

    //無賴做法
    public DialogueSystemTrigger dialogueSystemTrigger;


    public FacePlayerNormal facePlayer;

    [SerializeField] private bool firstTalk = true;

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

            facePlayer.enabled = true;

            if(firstTalk)
            {
                foreach (var trigger in this.GetComponents<DialogueSystemTrigger>())
                {
                    trigger.OnUse();
                }

                firstTalk = false;
            }
        }

    }

    public void DogOwnerEvent()
    {
        Debug.Log("Dog owner change position");
        transform.position = targetDog.position;
        transform.rotation = targetDog.rotation;

        _agent.isStopped = true;
        _anim.SetBool("Walk", false);
        _anim.SetBool("Fall", false);

        facePlayer.enabled = true;
        
        StartCoroutine(ExecuteInSequence());
        
    }

    private IEnumerator ExecuteInSequence()
    {
        DialogueLua.SetVariable("TASK_3_4_ARRIVE", true);

        // Wait for a short amount of time (e.g., 0.1 seconds) before executing the next line
        // 在执行下一行代码之前等待一小段时间（例如，0.1秒）
        yield return new WaitForSeconds(0.1f);

        dialogueSystemTrigger.OnUse();

        //DogOwner's transform, not walking around
        target = transform;
    }


    public void WalkToPlayer()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class ToiletKid : MonoBehaviour
{
    public Transform targetNPC;
    public float WalkValue;
    public float StopValue;

    public Transform targetPoint;

    public FacePlayerNormal facePlayer;

    public Transform npcPosition;

    private NavMeshAgent _agent;
    private Animator _anim;
    private Transform target;

    public BoxCollider trigger;

    [SerializeField] private bool firstTalk = true;

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

            if (firstTalk)
            {
                foreach (var trigger in this.GetComponents<DialogueSystemTrigger>())
                {
                    trigger.OnUse();
                }

                firstTalk = false;
            }
        }
    }
    
/*    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            DialogueLua.SetVariable("TASK_4_1_ARRIVE", true);
            target = targetPoint;
        }
    }*/

    public void StayAndTalk()
    {
        transform.position = npcPosition.transform.position;

        _agent.isStopped = true;
        _anim.SetBool("Walk", false);
        _anim.SetBool("Fall", false);

        target = transform;
        DialogueLua.SetVariable("TASK_4_1_ARRIVE", true);

        foreach (var item in this.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }

        trigger.enabled = false;

    }
}

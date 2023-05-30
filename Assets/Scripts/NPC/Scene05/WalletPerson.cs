using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class WalletPerson : MonoBehaviour
{
    public float WalkValue;
    public float StopValue;
    public Transform targetPosition;
    public GameObject phone;
    public GameObject phoneCanvas;
    public List<GameObject> customer;

    private NavMeshAgent _agent;
    private Animator _anim;
    //public FacePlayerNormal facePlayer;
    private Transform target;
    private bool activatePhone;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        activatePhone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
                //facePlayer.enabled = false;
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);
                //facePlayer.enabled = true;

                if(!activatePhone)
                {
                    phone.SetActive(true);
                    activatePhone = true;
                }

                phoneCanvas.SetActive(true);
                foreach (var item in customer)
                {
                    item.SetActive(false);
                }

                target = transform;
                _agent.isStopped = true;
                transform.position = new Vector3(-7.9f, 0.103f, -134.85f);
                //切换canvas
                //this.GetComponent<OverrideDialogueUI>().ui = GameObject.Find(childUIName);
                //和玩家对话
                //this.GetComponent<DialogueSystemTrigger>().OnUse();
            }
        }
    }



    public void WalkTowardTheLift()
    {
        target = targetPosition;
        _agent.SetDestination(target.position);
    }
}

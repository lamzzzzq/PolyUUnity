using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class Volunteer : MonoBehaviour
{
    // 定义UnityEvent
    public UnityEvent reachedPlayerEvent;

    public Transform player;
    private NavMeshAgent _agent;
    private Animator _anim;
    private Transform target;

    public FacePlayerNormal facePlayer;

    [SerializeField] private bool firstTalk = true;

    public float WalkValue;
    public float StopValue;

    private void Start()
    {
        target = player;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _agent.SetDestination(target.transform.position);

        if (Vector3.Distance(transform.position, target.position) > WalkValue)
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
            facePlayer.enabled = true;
            if (firstTalk)
            {
                reachedPlayerEvent?.Invoke();
                firstTalk = false;
            }
        }

    }

    private void OnDisable()
    {
        // 取消订阅事件，确保在禁用脚本时取消订阅，避免潜在的内存泄漏
        reachedPlayerEvent = null;
    }

    
    public void ReachedAndTalk()
    {
        foreach (var trigger in this.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }

}

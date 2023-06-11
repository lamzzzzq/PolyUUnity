using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class Volunteer : MonoBehaviour
{
    // ����UnityEvent
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
        // ȡ�������¼���ȷ���ڽ��ýű�ʱȡ�����ģ�����Ǳ�ڵ��ڴ�й©
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

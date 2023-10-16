using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class ProSocial_NPC_Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public GameObject conversation;
    public Transform teacherDestination;
    public Transform teacherDestinationOutside;
    public Transform teacherSecondDestination;
    private Transform teacherStand;
    public float walkValue, stopValue;
    public FacePlayerNormal facePlayer;

    //用於控制teacher的行走時機
    private bool walk;
    private bool hasTalk = false;
    public bool hasFinish = false;
    private bool hasDisappear = false;
    private bool idle = false;
    private bool backToClass = false;


    // Start is called before the first frame update
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();
        moveToDestination();
        teacherStand = teacherDestination;
    }

    // Update is called once per frame
    void Update()
    {
        //前進至目標地點，face特定位置，播放動畫，startconversation，玩家點擊才開始loading（同時disable movement during class）
        if(walk)
        {
            if(Vector3.Distance(transform.position,teacherDestination.position)>walkValue)
            {
                Debug.Log("walk");
                _agent.isStopped = false;
                _anim.SetBool("Walk",true);
                _anim.SetBool("Idle", false);
            }

            if(Vector3.Distance(transform.position, teacherDestination.position) < stopValue)
            {
                Debug.Log("stop");
                _agent.isStopped = true;
                if (idle)
                {
                    _anim.SetBool("Idle", true);
                }
                else
                {
                    _anim.SetBool("Walk", false);
                }

                facePlayer.enabled = true;
                if(!hasTalk)
                {
                    foreach (var item in conversation.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    hasTalk = true;
                }

                if(!hasFinish)
                {
                    foreach (var item in conversation.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    hasFinish = true;
                }

                if (backToClass)
                {
                    foreach (var item in conversation.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    backToClass = false;
                }
                if(hasDisappear)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void moveToDestination()
    {
        walk = true;
        _agent.SetDestination(teacherDestination.position);
    }

    public void moveOut()
    {
        Debug.Log("moveOut method called");
        facePlayer.enabled = false;
        walk = true;
        teacherDestination = teacherDestinationOutside; // 更新 teacherDestination 为 teacherDestinationOutside
        _agent.SetDestination(teacherDestination.position);

        hasDisappear = true;
    }

    public void moveToSecondPoint()
    {
        Debug.Log("moveToSecondPoint method called");
        facePlayer.enabled = false;
        walk = true;
        teacherDestination = teacherSecondDestination; // 更新 teacherDestination 为 teacherDestinationOutside
        _agent.SetDestination(teacherDestination.position);
        idle = true;
    }

    public void moveBackToStage()
    {
        Debug.Log("moveBackToStage method called");
        facePlayer.enabled = false;
        _agent.SetDestination(teacherStand.position);
        idle = false;
        backToClass = true;
    }
}

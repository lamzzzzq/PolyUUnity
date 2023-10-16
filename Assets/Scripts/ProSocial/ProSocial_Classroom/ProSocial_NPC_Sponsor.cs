using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class ProSocial_NPC_Sponsor : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public GameObject conversation;
    public Transform npcDestination;
    public Transform npcDestinationOutside;

    public float walkValue, stopValue;
    public FacePlayerNormal facePlayer;

    //用於控制teacher的行走時機
    private bool walk;
    private bool hasTalk = false;
    public bool hasFinish = false;
    private bool hasDisappear = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();
        moveToDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //前進至目標地點，face特定位置，播放動畫，startconversation，玩家點擊才開始loading（同時disable movement during class）
        if (walk)
        {
            if (Vector3.Distance(transform.position, npcDestination.position) > walkValue)
            {
                Debug.Log("walk");
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
            }

            if (Vector3.Distance(transform.position, npcDestination.position) < stopValue)
            {
                Debug.Log("stop");
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                facePlayer.enabled = true;
                if (!hasTalk)
                {
                    foreach (var item in conversation.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    hasTalk = true;
                }

                if (!hasFinish)
                {
                    foreach (var item in conversation.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    hasFinish = true;
                }

                if (hasDisappear)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void moveToDestination()
    {
        walk = true;
        _agent.SetDestination(npcDestination.position);
    }

    public void moveOut()
    {
        Debug.Log("moveOut method called");
        facePlayer.enabled = false;
        walk = true;
        npcDestination = npcDestinationOutside; // 更新 teacherDestination 为 teacherDestinationOutside
        _agent.SetDestination(npcDestination.position);

        hasDisappear = true;
    }


}

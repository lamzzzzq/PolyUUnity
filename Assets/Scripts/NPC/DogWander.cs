using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public enum DogStates { PATROL, READYTOTALK }
[RequireComponent(typeof(NavMeshAgent))]
public class DogWander : MonoBehaviour
{
    private EnemyStates enemystates;
    private NavMeshAgent agent;
    private Animator anim;
    public FacePlayerNormal faceplayer;
    public Transform SleepPoint;

    //public DogSleepTriggerOnPlayer DogSleep;

    [Header("Basic Settings")]
    public float sightRadius;
    public bool isGuard;

    private GameObject attackTarget;

    public float lookAtTime;
    private float remainLookAtTime;

    [Header("Patrol State")]
    public float patrolRange;

    private Vector3 wayPoint;
    private Vector3 guardPos;

    //bool配合動畫
    bool isWalk;
    bool isTalk;
    bool isSleep;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        guardPos = transform.position;

        remainLookAtTime = lookAtTime;
    }

    private void Start()
    {
        enemystates = EnemyStates.PATROL;
        GetNewWayPoint();
    }

    private void Update()
    {
/*        //if((DogSleep.PlayerLeave == true ) && (DialogueLua.GetVariable("TASK_3_4_ARRIVE").asBool == false))
        if (DialogueLua.GetVariable("TASK_3_4_ARRIVE").asBool == false)
        {
            agent.destination = SleepPoint.position;
            isSleep = true;
        }
        else
        {*/
            SwitchStates();
            SwitchAnimation();
        //}
    }

    void SwitchAnimation()
    {
        anim.SetBool("Walk", isWalk);
        anim.SetBool("Talk", isTalk);
        anim.SetBool("Sleep", isSleep);
    }

    void SwitchStates()
    {
        //爲什麽寫在這裏？
        if (FoundPlayer())
        {
            enemystates = EnemyStates.READYTOTALK;
            //Debug.Log("找到Player");
        }

        //如果發現player 要切換到追擊狀態chase
        switch (enemystates)
        {
            case EnemyStates.PATROL:
                {
                    //判断是否走到了随机巡逻点
                    if (Vector3.Distance(wayPoint, transform.position) <= agent.stoppingDistance)
                    {
                        isWalk = false;
                        if (remainLookAtTime > 0)
                        {
                            remainLookAtTime -= Time.deltaTime;
                        }
                        else
                        {
                            GetNewWayPoint();
                        }
                    }
                    else
                    {
                        isWalk = true;
                        //agent.destination = wayPoint;
                    }
                }
                break;

            case EnemyStates.READYTOTALK:
                //Todo:望向player
                //TODO:停止移动
                //TODO：配合動畫
                if (!FoundPlayer())
                {
                    Debug.Log("没找到Player");
                    //TODO：拉脫回到上一個狀態
                    faceplayer.enabled = false;
                    enemystates = EnemyStates.PATROL;
                    GetNewWayPoint();
                }
                else
                {
                    Debug.Log("找到Player");
                    faceplayer.enabled = true;
                    isWalk = false;
                    agent.destination = transform.position;
                }
                break;
        }
    }


    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("SubPlayer"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }


    //这段代码再看一遍吧
    void GetNewWayPoint()
    {
        remainLookAtTime = lookAtTime;

        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);

        Vector3 randomPoint = new Vector3(guardPos.x + randomX, transform.position.y, guardPos.z + randomZ);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, patrolRange, 1))
        {
            wayPoint = hit.position;
            agent.SetDestination(wayPoint); // Set the destination here.
        }
        else
        {
            wayPoint = transform.position;
            agent.SetDestination(wayPoint); // Set the destination here.
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, patrolRange);
    }
}




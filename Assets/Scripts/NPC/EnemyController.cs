using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates {GUARD, PATROL, CHASE}
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private EnemyStates enemystates;

    private NavMeshAgent agent;

    [Header("Basic Settings")]
    public float sightRadius;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SwitchStates();
    }







    void SwitchStates()
    {   
        //爲什麽寫在這裏？
        if(FoundPlayer())
        {
            enemystates = EnemyStates.CHASE;
            Debug.Log("找到Player");
        }


        //如果發現player 要切換到追擊狀態chase
        switch (enemystates)
        {
            case EnemyStates.GUARD:
                break;
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                break;
        }
    }


    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach(var target in colliders)
        {
            if(target.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class BorrowNPC : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform targetPosition;
    public float walkValue, stopValue;
    public FacePlayerNormal facePlayer;
    public GameObject player;
    public GameObject classmate;
    public Transform classmatePosition;

    public SphereCollider collider;
    private float arrivalThreshold = 0.7f; // ��NPC��Ŀ��λ�õľ���С�ڻ���ڴ�ֵʱ��������ΪNPC�Ѿ�����Ŀ�ĵ�


    public bool walk = false;
    public bool firstTimeTalk = true;
    public bool isTalkingWithClassmate = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            if (Vector3.Distance(transform.position, targetPosition.transform.position) > walkValue)
            {
                _agent.isStopped = false;
                isWalk();
            }

            if (Vector3.Distance(transform.position, targetPosition.transform.position) < stopValue)
            {
                _agent.isStopped = true;

                if (isTalkingWithClassmate) // ���������ͬѧ��̸����ô������ҽ�̸
                    return;

                isTalk();

                if (firstTimeTalk)
                {
                    foreach (var item in this.GetComponents<DialogueSystemTrigger>())
                    {
                        item.OnUse();
                    }
                    firstTimeTalk = false;
                }
            }
        }
    }

    public void moveToClassmate()
    {
        walk = true;
        isTalkingWithClassmate = true;
        targetPosition = classmatePosition.transform;
        _agent.SetDestination(targetPosition.position);
        Debug.Log("Moving to classmate at position: " + targetPosition.position);
        StartCoroutine(CheckArrivalAtClassmate());
    }

    public void moveToPlayer()
    {
        targetPosition = player.transform;
        walk = true;
        _agent.SetDestination(targetPosition.position);
        Debug.Log("Moving to player at position: " + targetPosition.position);
    }


    IEnumerator CheckArrivalAtClassmate()
    {
        float distance;
        do
        {
            distance = Vector3.Distance(transform.position, classmatePosition.position);
            Debug.Log("Current distance to classmate: " + distance);
            yield return null; // �ȴ���һ֡
        } while (distance > arrivalThreshold);

        // ����Ŀ��λ�ú󣬿�ʼ��ͬѧ��̸��Э��
        StartCoroutine(TalkWithClassmateCoroutine());
    }



    IEnumerator TalkWithClassmateCoroutine()
    {
        // �ڴ������ͬѧ��̸�Ĵ���
        // ����ͬѧ�Ľ�̸������

        // �������NPC��animation1
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isTalk", true);


        // ��ȡ����NPC��Animator��������Ŷ���
        Animator otherNpcAnimator = classmate.GetComponent<Animator>();

        if (otherNpcAnimator != null)
        {
            Debug.Log("Animator component found on classmate.");
        }
        else
        {
            Debug.Log("Animator component NOT found on classmate.");
        }

        if (otherNpcAnimator.runtimeAnimatorController != null)
        {
            foreach (AnimationClip clip in otherNpcAnimator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == "AnimationA")
                {
                    Debug.Log("'AnimationA' exists in the Animator.");
                    break;
                }
            }
        }
        else
        {
            Debug.Log("No runtime animator controller found on the Animator component.");
        }

        otherNpcAnimator.Play("AnimationA");

        if (otherNpcAnimator.GetCurrentAnimatorStateInfo(0).IsName("AnimationA"))
        {
            Debug.Log("'AnimationA' is currently playing.");
        }
        else
        {
            Debug.Log("'AnimationA' is NOT playing.");
        }


        // �ȴ�4��
        yield return new WaitForSeconds(8);

        // ��ͬѧ�Ľ�̸�����������ƶ������
        isTalkingWithClassmate = false; // ���ò�����ͬѧ��̸
        moveToPlayer();
    }



 

    private void isWalk()
    {
        _anim.SetBool("isWalk", true);
        _anim.SetBool("isTalk", false);
    }

    private void isTalk()
    {
        facePlayer.enabled = true;
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isTalk", true);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Octopus"))
        {
            QuestLog.SetQuestState("Classroom_TASK_3",QuestState.Abandoned);

            foreach (var item in this.GetComponents<DialogueSystemTrigger>())
            {
                item.OnUse();
            }

            collision.gameObject.SetActive(false);
        }
        
    }

}

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
    private float arrivalThreshold = 0.7f; // 当NPC与目标位置的距离小于或等于此值时，我们认为NPC已经到达目的地


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

                if (isTalkingWithClassmate) // 如果正在与同学交谈，那么不与玩家交谈
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
            yield return null; // 等待下一帧
        } while (distance > arrivalThreshold);

        // 到达目标位置后，开始与同学交谈的协程
        StartCoroutine(TalkWithClassmateCoroutine());
    }



    IEnumerator TalkWithClassmateCoroutine()
    {
        // 在此添加与同学交谈的代码
        // 当与同学的交谈结束后：

        // 播放这个NPC的animation1
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isTalk", true);


        // 获取其他NPC的Animator组件并播放动画
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


        // 等待4秒
        yield return new WaitForSeconds(8);

        // 与同学的交谈结束，现在移动到玩家
        isTalkingWithClassmate = false; // 设置不再与同学交谈
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

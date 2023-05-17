using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class Teacher : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public HelpTeacher helpTeacher;

    public List<GameObject> TriggerPoints = new List<GameObject>();
    public GameObject canvas;

    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    Transform Target;

    public GameObject npc;

    bool Fall;
    private bool disableMovement = false;

    public FacePlayerNormal faceplayer;

    void Start()
    {
        Target = Target3;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("Fall", false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.position) < 0.1f && Fall == true)
        {
            StopMoving();
            _anim.SetBool("Fall", true);
            StartCoroutine(GoToTheSecondPoint(3f));
        }
        if (Vector3.Distance(transform.position, Target.position) < 0.1f && Fall == false)
        {
            bool arrive = false;
            if(!arrive)
            {
                StopMoving();
                arrive = true;
            }

            //StartCoroutine(Delay(8f));

            for (int i = 0; i < TriggerPoints.Count; i++)
            {
                TriggerPoints[i].SetActive(false);
            }

            faceplayer.enabled = true;
            canvas.SetActive(true);

            //disable player movement
            if(!disableMovement)
            {
                helpTeacher.DisablePlayerController();
                disableMovement = true;
            }
            
        }
    }

    // Stop the NPC and update the animation state
    private void StopMoving()
    {
        _agent.isStopped = true;
        _anim.SetBool("Walk", false);
    }



    //First Step - Trigger By TeacherGreeting GameObject
    public void WalkTowardTheDoor()
    {
        _agent.isStopped = false;
        _agent.SetDestination(Target.transform.position);
        _anim.SetBool("Walk", true);
        _anim.SetBool("Fall", false);
        Fall = true;
    }

    private IEnumerator GoToTheSecondPoint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Target = Target2;
        _agent.SetDestination(Target.transform.position);
        _agent.isStopped = false;
        _anim.SetBool("Walk", true);
        _anim.SetBool("Fall", false);
        Fall = false;
    }

    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //_anim.SetBool("Walk", false); // Ensure Walk is set to false after the delay
    }

    public void TeacherGreeting()
    {
        //PixelCrushers.QuestMachine.QuestGiver.Start

        foreach (var trigger in npc.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}

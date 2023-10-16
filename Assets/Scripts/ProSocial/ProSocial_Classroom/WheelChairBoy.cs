using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class WheelChairBoy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    public FacePlayerNormal facePlayer; 


    public Transform targetPosition;
    public Transform areaPosition;
    public GameObject entryCanvas;
    public Transform screen;


    public float WalkValue, StopValue;

    private bool walk = false;
    private bool audioPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (walk)
        {
            if (Vector3.Distance(transform.position, targetPosition.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Move", true);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < StopValue)
            {
                if(!audioPlayed)
                {
                    entryCanvas.SetActive(true);
                    audioPlayed = true;
                }

                _agent.isStopped = true;
                _anim.SetBool("Move", false);

                Debug.Log("Arrive");
            }
        }
    }


    public void moveToDestination()
    {
        walk = true;
        _agent.SetDestination(targetPosition.position);
    }

    public void TurnToTalk()
    {
        facePlayer.enabled = true;
        foreach (var trigger in this.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }

    public void moveToArea()
    {
        walk = true;
        targetPosition = areaPosition;
        _agent.SetDestination(targetPosition.position);
    }

    public void focusOnScreen()
    {
        facePlayer.player = screen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PixelCrushers.DialogueSystem;

public class PhonePersonOntheGround : MonoBehaviour
{
    public float WalkValue;
    public float StopValue;
    public GameObject player;

    private Transform target;
    private NavMeshAgent _agent;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > WalkValue)
            {
                _agent.isStopped = false;
                _anim.SetBool("Walk", true);
                //facePlayer.enabled = false;
            }

            if (Vector3.Distance(transform.position, target.position) < StopValue)
            {
                _agent.isStopped = true;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Fall", false);

                foreach (var trigger in GetComponents<DialogueSystemTrigger>())
                {
                    trigger.OnUse();
                }
                target = transform;
            }
        }
    }

    public void WalkToPlayer()
    {
        target = player.transform;
        _agent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Interactive")
        {
            collision.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BNG;
using PixelCrushers.DialogueSystem;

public class NPCFallsDown : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform target1;
    bool Fall;
    Transform Target;

    public FruitDropOnPlayer dropScript;
    public Transform player;
    public TeleportPlayerFade teleport;

    public ScreenFader ScreenFader;

    public GameObject phone;
    public GameObject utensil;
    public GameObject holder;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        _anim.SetBool("Fall", false);

        Target = target1;

        _agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.isStopped = false;
    }


    public void WalkTowardTheDoor()
    {

        teleport.ResetPlayerPosRotWithParameters(player, ScreenFader);
        Target = target1;
        _agent.isStopped = false;
        _agent.SetDestination(Target.transform.position);
        _anim.SetBool("Walk", true);
        _anim.SetBool("Fall", false);
        Fall = true;
    }


    public void NPCFalls()
    {

        _anim.SetBool("Fall", true);
        Debug.Log("Yes.");

        StartCoroutine(DoSomething());
    }

    public void NPCPick()
    {
        phone.SetActive(false);
        utensil.SetActive(true);
        holder.SetActive(true);
        _anim.SetBool("Pick", true);
    }


    private IEnumerator DoSomething()
    {
        AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);
        float time = stateInfo.length;

        yield return new WaitForSeconds(time-1);

        dropScript.FruitDropCutSceneFirst();
    }


}

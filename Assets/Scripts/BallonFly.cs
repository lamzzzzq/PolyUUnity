using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BallonFly : MonoBehaviour
{
    public Vector3 target; // The target point that the balloon should move towards
    public float speed = 5f; // The speed at which the balloon should move
    public float rotationSpeed = 10f; // The speed at which the balloon should rotate

    Rigidbody rb; // The Rigidbody component of the balloon

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log("HELP" + DialogueLua.GetVariable("TASK_4_4_HELP").asBool);
        Debug.Log("HELP" + DialogueLua.GetVariable("TASK_4_4_ARRIVE").asBool);
        Debug.Log("HELP" + DialogueLua.GetVariable("GetBallon").asBool);


        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
/*        if(other.tag == "SubPlayer")
        {
            DialogueLua.SetVariable("TASK_4_4_ARRIVE", true);
        }*/

    }
}

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
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftClose : MonoBehaviour
{
    public Transform doorTransform;
    public Vector3 openPosition;
    public float openSpeed = 1f;
    public float closeDelay = 5f;

    private bool isTriggerActive = false;
    private Vector3 closedPosition;

    private void Start()
    {
        closedPosition = doorTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        CloseDoor();
        //Invoke("CloseDoor", closeDelay);
    }

    private void CloseDoor()
    {
        doorTransform.position = Vector3.Lerp(openPosition, closedPosition, openSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;


public class InstantiateAndGrab : MonoBehaviour
{
    public GameObject ObjectToCreate;

    GameObject go;
    Grabbable grabbable;
    Grabber grabber;

    private void OnTriggerEnter(Collider other)
    {
        grabber = other.GetComponent<Grabber>();

        if(grabber != null && !grabber.HoldingItem)
        {
            go = GameObject.Instantiate(ObjectToCreate, grabber.transform.position, grabber.transform.rotation);

            grabbable = go.GetComponent<Grabbable>();

            grabber.GrabGrabbable(grabbable);
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.RightGripDown)
        {
            grabbable.CanBeDropped = true;
            grabber.TryRelease();
        }
    }
}

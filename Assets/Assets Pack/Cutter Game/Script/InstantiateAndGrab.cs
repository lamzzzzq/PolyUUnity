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

        if (grabber != null && !grabber.HoldingItem)
        {
            go = GameObject.Instantiate(ObjectToCreate, grabber.transform.position, Quaternion.identity);

            grabbable = go.GetComponent<Grabbable>();

            grabber.GrabGrabbable(grabbable);
        }
    }


    private void Update()
    {
        if (InputBridge.Instance.RightGripDown || InputBridge.Instance.LeftGripDown)
        {
            grabbable.CanBeDropped = true;
            grabber.TryRelease();
        }
    }




    //之后可以利用Enum进行左右手的区分，chatGPT教的
}

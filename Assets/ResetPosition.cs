using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.XR;

public class ResetPosition : MonoBehaviour
{
    public Transform XRrig;
    // Update is called once per frame
    void Update()
    {
        if ((InputBridge.Instance.XButton || Input.GetKeyDown(KeyCode.T)) && transform.parent == XRrig.transform)
        {

            Debug.Log("press");
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevices(devices);
            foreach (var eachDevice in devices)
            {
                eachDevice.subsystem.TryRecenter();
            }
        }
    }
}

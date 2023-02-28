using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion originalRotation;
    void Start()
    {
        originalRotation = transform.rotation;
    }
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.up);
        transform.rotation = rotation * originalRotation;
    }
}


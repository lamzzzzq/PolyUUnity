using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public float forceMaginitude = 5f;
    

    private Rigidbody rb;
    private bool isKnocked = false;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void KnockDown()
    {
        if (!isKnocked)
        {
            Vector3 forceDirection = transform.forward;
            rb.AddForce(forceDirection * forceMaginitude, ForceMode.Impulse);
            isKnocked = true;
        }
    }
}

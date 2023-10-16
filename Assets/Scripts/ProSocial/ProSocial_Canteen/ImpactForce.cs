using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactForce : MonoBehaviour
{

    public float force = 10f; // 撞击力
    public Vector3 direction = new Vector3(0, 1, 1); // 撞击方向
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 impactForce = direction.normalized * force;
        rb.AddForce(impactForce, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pear")) // 假设所有的笔都有一个叫 "Pen" 的标签
        {
            Rigidbody penRb = other.GetComponent<Rigidbody>();
            if (penRb != null)
            {
                Vector3 impactForce = direction.normalized * force;
                penRb.AddForce(impactForce, ForceMode.Impulse);
            }
        }
    }
}


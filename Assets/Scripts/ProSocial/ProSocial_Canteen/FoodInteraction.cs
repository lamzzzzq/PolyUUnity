using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class FoodInteraction : MonoBehaviour
{
    public GameObject[] children;
    public void OnGrab()
    {
        // ������ץȡʱ�Ĵ���
        // ...

        // �����Ӷ�������
        foreach (GameObject child in children)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            BoxCollider bc = child.GetComponent<BoxCollider>();
            Grabbable gb = child.GetComponent<Grabbable>();

            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                Debug.Log("Rigidbody found and modified");  // �����һ��
                // ... ������Ҫ�ı�� Rigidbody ����
            }
            if (bc != null) bc.enabled = false;
            if (gb != null) gb.enabled = false;
        }

/*        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<Grabbable>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;*/


    }

    public void OnRelease()
    {
        // �������ͷ�ʱ�Ĵ���
        // ...

        // ���������Ӷ�������
        foreach (GameObject child in children)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            BoxCollider bc = child.GetComponent<BoxCollider>();
            Grabbable gb = child.GetComponent<Grabbable>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                // ... ������Ҫ�ı�� Rigidbody ����
            }
            if (bc != null) bc.enabled = true;
            if (gb != null) gb.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class FoodInteraction : MonoBehaviour
{
    public GameObject[] children;
    public void OnGrab()
    {
        // 父对象被抓取时的代码
        // ...

        // 禁用子对象的组件
        foreach (GameObject child in children)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            BoxCollider bc = child.GetComponent<BoxCollider>();
            Grabbable gb = child.GetComponent<Grabbable>();

            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                Debug.Log("Rigidbody found and modified");  // 添加这一行
                // ... 其他需要改变的 Rigidbody 属性
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
        // 父对象被释放时的代码
        // ...

        // 重新启用子对象的组件
        foreach (GameObject child in children)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            BoxCollider bc = child.GetComponent<BoxCollider>();
            Grabbable gb = child.GetComponent<Grabbable>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                // ... 其他需要改变的 Rigidbody 属性
            }
            if (bc != null) bc.enabled = true;
            if (gb != null) gb.enabled = true;
        }
    }
}

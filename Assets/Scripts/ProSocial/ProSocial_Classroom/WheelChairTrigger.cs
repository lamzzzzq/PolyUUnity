using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelChairTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime = 2f;
    public bool isInside = false;
    private bool hasFunctionExecuted = false; // 检查函数是否已经执行过
    private int insideCount = 0; // 计数在触发器内的物体数量

    public UnityEvent onBoxExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isInside = true;
            insideCount++;  // 递增计数器
            StopCoroutine(WaitAndCheck());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Box"))
        {
            isInside = false;
            insideCount--;  // 递减计数器

            if (insideCount <= 0)
            {
                StartCoroutine(WaitAndCheck());
            }
        }
    }
    IEnumerator WaitAndCheck()
    {
        // 等待指定的时间
        yield return new WaitForSeconds(waitTime);

        // 如果物体在等待期间没有重新进入触发器，调用函数
        if (!isInside && !hasFunctionExecuted)
        {
            onBoxExitEvent.Invoke();
            hasFunctionExecuted = true;
        }
    }

}







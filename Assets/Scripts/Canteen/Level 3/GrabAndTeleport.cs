using UnityEngine;
using UnityEngine.Events;

public class GrabAndTeleport : MonoBehaviour
{
    public UnityEvent OnHandStay; // 在 Unity Editor 中可以设置这个事件
    private bool isHandInside = false;
    private float timeInside = 0f;
    private bool hasTriggered = false; // 新增：跟踪是否已触发

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SubPlayer"))
        {
            isHandInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SubPlayer"))
        {
            isHandInside = false;
            timeInside = 0f; // 重置时间
        }
    }

    private void Update()
    {
        if (isHandInside && !hasTriggered) // 修改：只有在没有触发的情况下才检测)
        {
            timeInside += Time.deltaTime;
            if (timeInside >= 2f) // 如果手停留了2秒
            {
                Debug.Log("Yes");
                OnHandStay?.Invoke(); // 调用 Unity 事件
                timeInside = 0f;
                hasTriggered = true;// 重置时间（如果你只想触发一次，可以设置 isHandInside = false;）
            }
        }
    }
}

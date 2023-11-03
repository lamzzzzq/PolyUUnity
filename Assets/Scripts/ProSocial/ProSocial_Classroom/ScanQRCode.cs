using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class ScanQRCode : MonoBehaviour
{

    public UnityEvent FocusCode; // 在 Unity Editor 中可以设置这个事件
    private bool isFocus = false;
    private float timeInside = 0f;
    private bool hasTriggered = false; // 新增：跟踪是否已触发

    private Renderer renderer;
    public Material oldMaterial;
    public Material newMaterial;

    public ProSocial_NPC_Teacher teacherScript;
    public ProSocial_NPC_Sponsor sponsorScript;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            isFocus = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            isFocus = false;
            timeInside = 0f; // 重置时间
        }
    }

    private void Update()
    {
        if (isFocus && !hasTriggered) // 修改：只有在没有触发的情况下才检测)
        {
            Debug.Log("Detected");
            timeInside += Time.deltaTime;
            if (timeInside >= 3f) // 如果手停留了3秒
            {
                Debug.Log("Yes");
                FocusCode?.Invoke(); // 调用 Unity 事件
                timeInside = 0f;
                hasTriggered = true;// 重置时间（如果你只想触发一次，可以设置 isHandInside = false;）
                updateQuestionaireMaterial();

                teacherTalk();
            }
        }
    }

    public void updateQuestionaireMaterial()
    {
        // 检查GameObject是否有Renderer组件
        if (renderer != null)
        {
            // 设置Renderer的材质
            renderer.material = newMaterial;
        }
    }

    public void updateChargingMaterial()
    {
        // 检查GameObject是否有Renderer组件
        if (renderer != null)
        {
            // 设置Renderer的材质
            renderer.material = oldMaterial;
        }
    }

    public void teacherTalk()
    {
        QuestLog.SetQuestState("Classroom_TASK_2", QuestState.Success);
        teacherScript.hasFinish = false;
    }
}


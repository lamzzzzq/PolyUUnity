using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class ScanQRCode : MonoBehaviour
{

    public UnityEvent FocusCode; // �� Unity Editor �п�����������¼�
    private bool isFocus = false;
    private float timeInside = 0f;
    private bool hasTriggered = false; // �����������Ƿ��Ѵ���

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
            timeInside = 0f; // ����ʱ��
        }
    }

    private void Update()
    {
        if (isFocus && !hasTriggered) // �޸ģ�ֻ����û�д���������²ż��)
        {
            Debug.Log("Detected");
            timeInside += Time.deltaTime;
            if (timeInside >= 3f) // �����ͣ����3��
            {
                Debug.Log("Yes");
                FocusCode?.Invoke(); // ���� Unity �¼�
                timeInside = 0f;
                hasTriggered = true;// ����ʱ�䣨�����ֻ�봥��һ�Σ��������� isHandInside = false;��
                updateQuestionaireMaterial();

                teacherTalk();
            }
        }
    }

    public void updateQuestionaireMaterial()
    {
        // ���GameObject�Ƿ���Renderer���
        if (renderer != null)
        {
            // ����Renderer�Ĳ���
            renderer.material = newMaterial;
        }
    }

    public void updateChargingMaterial()
    {
        // ���GameObject�Ƿ���Renderer���
        if (renderer != null)
        {
            // ����Renderer�Ĳ���
            renderer.material = oldMaterial;
        }
    }

    public void teacherTalk()
    {
        QuestLog.SetQuestState("Classroom_TASK_2", QuestState.Success);
        teacherScript.hasFinish = false;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_NPC_AnimationControl : MonoBehaviour
{
    public Animator animator;
    private float animationDuration;  // ��ǰ�����ĳ���ʱ��
    private bool canTriggerNext = true;  // �Ƿ���Դ�����һ������

    void Update()
    {
        if (canTriggerNext)
        {
            TriggerRandomAnimation();  // �����������
        }

        // ��ȡ��ǰ����״̬����Ϣ
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���㶯�����ŵĽ���
        float normalizedTime = stateInfo.normalizedTime % 1;

        // ��鶯���Ƿ��Ѿ��������
        if (normalizedTime >= 0.9f)
        {
            canTriggerNext = true;
        }
        else
        {
            canTriggerNext = false;
        }
    }

    void TriggerRandomAnimation()
    {
        int randomValue = Random.Range(0, 3);  // ����һ�� 0, 1, �� 2 �������

        // �������в���
        animator.SetBool("LookRight", false);
        animator.SetBool("PickScreen", false);
        animator.SetBool("ScratchHead", false);

        switch (randomValue)
        {
            case 0:
                animator.SetBool("LookRight", true);
                break;
            case 1:
                animator.SetBool("PickScreen", true);
                break;
            case 2:
                animator.SetBool("ScratchHead", true);
                break;
        }

        canTriggerNext = false;  // ���ñ�־����ֹ����������һ������
    }

    public void SetOnlyIdle()
    {
        animator.SetBool("OnlyIdle", true);
    }
}


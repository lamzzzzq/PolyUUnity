using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class Task5_NPC_AnimationControl : MonoBehaviour
{
    public Animator animator;  // Animator ���
    private Vector3 initialPosition;
    private bool isJumping = false;

    void Start()
    {
        // �洢��ʼλ��
        initialPosition = transform.position;
    }

    void Update()
    {
        // ��ȡ��ǰ����״̬
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ����Ƿ��ڲ�����Ծ����
        if (stateInfo.IsName("Jump"))
        {
            isJumping = true;
        }
        else if (isJumping)
        {
            // ���֮ǰ����Ծ�������ڶ����Ѿ�����������λ��
            transform.position = initialPosition;
            isJumping = false;
        }
    }


    public void playOctopus()
    {
        StartCoroutine(delayAnim());
    }

    private IEnumerator delayAnim()
    {
        yield return new WaitForSeconds(2f);
        animator.Play("Octopus");
    }

    public void setIdle()
    {
        animator.SetBool("Idle", true);
        transform.position = initialPosition;

        foreach (var item in this.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class Task5_NPC_AnimationControl : MonoBehaviour
{
    public Animator animator;  // Animator 组件
    private Vector3 initialPosition;
    private bool isJumping = false;

    void Start()
    {
        // 存储初始位置
        initialPosition = transform.position;
    }

    void Update()
    {
        // 获取当前动画状态
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 检查是否在播放跳跃动画
        if (stateInfo.IsName("Jump"))
        {
            isJumping = true;
        }
        else if (isJumping)
        {
            // 如果之前在跳跃，但现在动画已经结束，重置位置
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

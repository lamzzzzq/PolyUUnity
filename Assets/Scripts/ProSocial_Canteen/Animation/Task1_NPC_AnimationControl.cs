using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1_NPC_AnimationControl : MonoBehaviour
{
    public Animator animator;
    private float animationDuration;  // 当前动画的持续时间
    private bool canTriggerNext = true;  // 是否可以触发下一个动画

    void Update()
    {
        if (canTriggerNext)
        {
            TriggerRandomAnimation();  // 触发随机动画
        }

        // 获取当前动画状态的信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 计算动画播放的进度
        float normalizedTime = stateInfo.normalizedTime % 1;

        // 检查动画是否已经播放完毕
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
        int randomValue = Random.Range(0, 3);  // 生成一个 0, 1, 或 2 的随机数

        // 重置所有参数
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

        canTriggerNext = false;  // 设置标志，防止立即触发下一个动画
    }

    public void SetOnlyIdle()
    {
        animator.SetBool("OnlyIdle", true);
    }
}


using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCAnimation : MonoBehaviour
{
    private Animator animator;
    [Range(0, 1)] public float maxDelay = 0.5f; // 最大延迟时间，你可以根据需要调整

    private void Start()
    {
        animator = GetComponent<Animator>();

        // 随机选择一个动画并播放
        float randomAnimValue = Random.Range(0f, 1f); // 0到1之间的随机值
        animator.SetFloat("RandomAnim", randomAnimValue); // 设置Animation Controller中的参数

        // 随机延迟播放动画
        float randomDelay = Random.Range(0f, maxDelay);
        StartCoroutine(PlayAnimationWithDelay(randomDelay));
    }

    private IEnumerator PlayAnimationWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
    }
}
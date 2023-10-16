using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCAnimation : MonoBehaviour
{
    private Animator animator;
    [Range(0, 1)] public float maxDelay = 0.5f; // ����ӳ�ʱ�䣬����Ը�����Ҫ����

    private void Start()
    {
        animator = GetComponent<Animator>();

        // ���ѡ��һ������������
        float randomAnimValue = Random.Range(0f, 1f); // 0��1֮������ֵ
        animator.SetFloat("RandomAnim", randomAnimValue); // ����Animation Controller�еĲ���

        // ����ӳٲ��Ŷ���
        float randomDelay = Random.Range(0f, maxDelay);
        StartCoroutine(PlayAnimationWithDelay(randomDelay));
    }

    private IEnumerator PlayAnimationWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
    }
}
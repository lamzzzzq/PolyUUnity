using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelChairTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime = 2f;
    public bool isInside = false;
    private bool hasFunctionExecuted = false; // ��麯���Ƿ��Ѿ�ִ�й�
    private int insideCount = 0; // �����ڴ������ڵ���������

    public UnityEvent onBoxExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isInside = true;
            insideCount++;  // ����������
            StopCoroutine(WaitAndCheck());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Box"))
        {
            isInside = false;
            insideCount--;  // �ݼ�������

            if (insideCount <= 0)
            {
                StartCoroutine(WaitAndCheck());
            }
        }
    }
    IEnumerator WaitAndCheck()
    {
        // �ȴ�ָ����ʱ��
        yield return new WaitForSeconds(waitTime);

        // ��������ڵȴ��ڼ�û�����½��봥���������ú���
        if (!isInside && !hasFunctionExecuted)
        {
            onBoxExitEvent.Invoke();
            hasFunctionExecuted = true;
        }
    }

}







using UnityEngine;
using UnityEngine.Events;

public class GrabAndTeleport : MonoBehaviour
{
    public UnityEvent OnHandStay; // �� Unity Editor �п�����������¼�
    private bool isHandInside = false;
    private float timeInside = 0f;
    private bool hasTriggered = false; // �����������Ƿ��Ѵ���

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
            timeInside = 0f; // ����ʱ��
        }
    }

    private void Update()
    {
        if (isHandInside && !hasTriggered) // �޸ģ�ֻ����û�д���������²ż��)
        {
            timeInside += Time.deltaTime;
            if (timeInside >= 2f) // �����ͣ����2��
            {
                Debug.Log("Yes");
                OnHandStay?.Invoke(); // ���� Unity �¼�
                timeInside = 0f;
                hasTriggered = true;// ����ʱ�䣨�����ֻ�봥��һ�Σ��������� isHandInside = false;��
            }
        }
    }
}

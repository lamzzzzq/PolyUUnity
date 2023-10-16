using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image imageToFill;  // Image ���
    public float duration = 10f; // ��ʱ��Ϊ 5 ��
    public AudioSource clockSound;  // ʱ������
    public GameObject objectToDisable;  // Ҫ���õĶ���
    public LoadingOnPlayer loadingOnPlayer;

    void Start()
    {
        // ��� AudioSource û���� Inspector �����ã�������ͬһ GameObject �ϻ�ȡ��
        if (clockSound == null)
        {
            clockSound = GetComponent<AudioSource>();
        }

        // ��ʼ���Ͳ�������\
        LoadingEvent();


    }

    public void LoadingEvent()
    {
        StartCoroutine(FillImageAndSoundOverTime());
    }


    IEnumerator FillImageAndSoundOverTime()
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        float elapsedTime = 0f;

        // ��ʼ��������
        if (clockSound != null)
        {
            clockSound.Play();
        }

        while (Time.time < endTime)
        {
            elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / duration;
            imageToFill.fillAmount = normalizedTime;

            // �����Ƶֹͣ�����¿�ʼ����
            if (clockSound != null && !clockSound.isPlaying)
            {
                clockSound.Play();
            }


            yield return null;
        }

        // ȷ���ڽ���ʱ fillAmount �� 1
        imageToFill.fillAmount = 1f;

        // ֹͣ��������
        if (clockSound != null)
        {
            clockSound.Stop();
        }
        Debug.Log("1");

        // �����ض��� GameObject
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log("2");
        }

        loadingOnPlayer.SwitchToNormal();
    }
}
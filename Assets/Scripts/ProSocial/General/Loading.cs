using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image imageToFill;  // Image 组件
    public float duration = 10f; // 总时长为 5 秒
    public AudioSource clockSound;  // 时钟声音
    public GameObject objectToDisable;  // 要禁用的对象
    public LoadingOnPlayer loadingOnPlayer;

    void Start()
    {
        // 如果 AudioSource 没有在 Inspector 中设置，尝试在同一 GameObject 上获取它
        if (clockSound == null)
        {
            clockSound = GetComponent<AudioSource>();
        }

        // 开始填充和播放声音\
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

        // 开始播放声音
        if (clockSound != null)
        {
            clockSound.Play();
        }

        while (Time.time < endTime)
        {
            elapsedTime = Time.time - startTime;
            float normalizedTime = elapsedTime / duration;
            imageToFill.fillAmount = normalizedTime;

            // 如果音频停止，重新开始播放
            if (clockSound != null && !clockSound.isPlaying)
            {
                clockSound.Play();
            }


            yield return null;
        }

        // 确保在结束时 fillAmount 是 1
        imageToFill.fillAmount = 1f;

        // 停止播放声音
        if (clockSound != null)
        {
            clockSound.Stop();
        }
        Debug.Log("1");

        // 禁用特定的 GameObject
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log("2");
        }

        loadingOnPlayer.SwitchToNormal();
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public GameObject objectToShow;
    public AudioClip audioClip_next, audioClip_step;

    private bool objectShown = false;

    private void Start()
    {
        // 设置VideoPlayer的音频输出为AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

/*        // 监听视频播放时间事件
        videoPlayer.loopPointReached += OnVideoLoopPointReached;*/

        // 播放音频
        audioSource.Play();

        // 监听音频播放结束事件
        audioSource.loop = false;
        audioSource.clip.LoadAudioData();
        float audioLength = audioSource.clip.length;
        Invoke("StartVideoPlayback", audioLength);
    }

    private void StartVideoPlayback()
    {
        // 播放视频
        videoPlayer.Play();

        // Play audio 
        audioSource.PlayOneShot(audioClip_step);

        Count30Seconds();
    }

    private void OnVideoLoopPointReached(VideoPlayer vp)
    {
        // 当视频播放到循环点时触发
        if (vp.time >= 30f && !objectShown)
        {
            // 在第30秒后显示游戏对象
            objectToShow.SetActive(true);
            objectShown = true;
        }
    }

    private void Count30Seconds()
    {
        StartCoroutine(count30SecondsAndRun());
    }

    private IEnumerator count30SecondsAndRun()
    {
        yield return new WaitForSeconds(10f);
        objectToShow.SetActive(true);
        audioSource.PlayOneShot(audioClip_next);
    }
}

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
        // ����VideoPlayer����Ƶ���ΪAudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

/*        // ������Ƶ����ʱ���¼�
        videoPlayer.loopPointReached += OnVideoLoopPointReached;*/

        // ������Ƶ
        audioSource.Play();

        // ������Ƶ���Ž����¼�
        audioSource.loop = false;
        audioSource.clip.LoadAudioData();
        float audioLength = audioSource.clip.length;
        Invoke("StartVideoPlayback", audioLength);
    }

    private void StartVideoPlayback()
    {
        // ������Ƶ
        videoPlayer.Play();

        // Play audio 
        audioSource.PlayOneShot(audioClip_step);

        Count30Seconds();
    }

    private void OnVideoLoopPointReached(VideoPlayer vp)
    {
        // ����Ƶ���ŵ�ѭ����ʱ����
        if (vp.time >= 30f && !objectShown)
        {
            // �ڵ�30�����ʾ��Ϸ����
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

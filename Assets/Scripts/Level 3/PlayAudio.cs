using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject canvas;
    public void PlayAudioOnce()
    {
        StartCoroutine(PlayAudioAndCoroutine());
    }

    private IEnumerator PlayAudioAndCoroutine()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(5);
        canvas.SetActive(false);

    }



}

using UnityEngine;
using System.Collections;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    private bool hasPlayed;

    private void Start()
    {
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            StartCoroutine(PlayAudio());
        }
    }

    private IEnumerator PlayAudio()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioClip.length);
        // Optional: audioSource.enabled = false; if you want to disable the audio source.
    }
}

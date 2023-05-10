using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonController : MonoBehaviour
{
    public Button welcomePanelButton;
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void Start()
    {
        PlayAudioAndDisableButton();


    }

    public void PlayAudioAndDisableButton()
    {
        StartCoroutine(PlayAudioAndWait());
    }

    private IEnumerator PlayAudioAndWait()
    {
        welcomePanelButton.interactable = false;
        yield return new WaitForSeconds(2);
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(audioClip.length);
        welcomePanelButton.interactable = true;


    }
}

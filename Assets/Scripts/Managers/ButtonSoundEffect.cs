using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonSoundEffect : MonoBehaviour
{
    public AudioClip soundEffect;
    public float soundVolume = 1f;

    private Button button;
    private AudioSource audioSource;

    private void Awake()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        // Create an AudioSource component if it doesn't exist
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioClip and volume for the AudioSource
        audioSource.clip = soundEffect;
        audioSource.volume = soundVolume;
    }

    public void PlaySoundAndDisableButton()
    {
        // Play the sound effect
        audioSource.Play();

        // Disable the button after a delay
        StartCoroutine(DisableButtonAfterSoundFinished());
    }

    private IEnumerator DisableButtonAfterSoundFinished()
    {
        // Wait for the sound to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Disable the button
        button.interactable = false;
        gameObject.SetActive(false);
    }
}

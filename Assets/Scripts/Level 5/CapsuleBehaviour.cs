using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehaviour : MonoBehaviour
{
    public GameObject Capsule;
    public AudioClip audioClip;
    public AudioSource audioSource;

    public void HoldAndDisappear()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(4);
        Capsule.SetActive(false);
    }
}

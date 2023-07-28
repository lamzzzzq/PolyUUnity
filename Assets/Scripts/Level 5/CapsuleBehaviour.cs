using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehaviour : MonoBehaviour
{
    public GameObject Capsule;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public GameObject capsule_obj;
    public AudioClip audioClip_Disappear;

    public GameObject particlePrefab;

    public void HoldAndDisappear()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(4);
        


        // Instantiate the particle system prefab at the position of the Capsule
        GameObject particleEffect = Instantiate(particlePrefab, capsule_obj.transform.position, Quaternion.identity);

        // Wait for the particle effect to finish playing
        ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(particleSystem.main.duration);

        // Destroy the particle effect object
        Destroy(particleEffect);
        audioSource.clip = audioClip_Disappear;
        audioSource.Play();
        Capsule.SetActive(false);

    }
}

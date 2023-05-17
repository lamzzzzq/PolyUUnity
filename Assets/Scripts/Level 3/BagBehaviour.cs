using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fruit"))
        {
            other.gameObject.SetActive(false);

            audioSource.PlayOneShot(audioClip);
        }
    }
}

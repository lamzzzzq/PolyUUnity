using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonationMachineOnPlayer : MonoBehaviour
{
    private bool firstEnter = false;
    public GameObject canvas;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SubPlayer")
        {
            Debug.Log("Unexpecetd");
            if(!firstEnter)
            {
                canvas.SetActive(true);
                audioSource.PlayOneShot(audioClip);
                firstEnter = true;
            }
        }
    }
}

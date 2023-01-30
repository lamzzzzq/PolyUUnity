using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

public class BubbleGun : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioSource audioSource;

    private bool keyPress;

    private void Update()
    {
        if(InputBridge.Instance.LeftTriggerDown || InputBridge.Instance.RightTriggerDown)
        {
            keyPress = true;
            Debug.Log(keyPress);
        }
        if (InputBridge.Instance.LeftTriggerUp || InputBridge.Instance.RightTriggerUp)
        {
            keyPress = false;
            Debug.Log(keyPress);
        }

        if(keyPress)
        {
            particleSystem.Play();
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void Shoot()
    {
        particleSystem.Play();
    }
}

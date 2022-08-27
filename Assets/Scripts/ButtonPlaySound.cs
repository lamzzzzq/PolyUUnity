using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaySound : MonoBehaviour
{
    public AudioSource SoundPlayer;

    public void playThisSound()
    {
        SoundPlayer.Play();
    }
}

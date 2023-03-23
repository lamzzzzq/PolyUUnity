using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Lucy : MonoBehaviour
{
    public List<GameObject> gameObject = new List<GameObject>();
    public bool waterPoured = false;
    public AudioSource _audio;
    public Animator _anim;
    public FacePlayerNormal _facePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (QuestLog.GetQuestState("2.1_TeacherDropItem") == QuestState.Abandoned)
        {
            if (other.gameObject.CompareTag("SubPlayer") && (waterPoured == false))
            {
                _facePlayer.enabled = true;
                PlayAnimation();
                WaterFadeIn();
            }
            _audio.enabled = false;
        }
    }

    public void PlayAnimation()
    {
        _audio.Play();
        _anim.enabled = true;
    }

    public void WaterFadeIn()
    {
        for (int i = 0; i < gameObject.Count; i++)
        {
            gameObject[i].GetComponent<WaterFadeIn>().StartFading();
        }
        waterPoured = true;
    }
}

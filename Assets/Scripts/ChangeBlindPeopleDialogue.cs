using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ChangeBlindPeopleDialogue : MonoBehaviour
{
    public FacePlayer facePlayer;
    private bool TASK_3_2_DONE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            DialogueLua.SetVariable("TASK_3_2_DONE", true);
        }
    }
}

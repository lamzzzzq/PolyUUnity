using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class WheelChair : MonoBehaviour
{
    public void NPCTalk()
    {
        this.GetComponent<DialogueSystemTrigger>().OnUse();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ConversationControl : MonoBehaviour
{
    public int waitSeconds;
    public void EndConversation()
    {
        StartCoroutine(DelayAndStopConversation());
    }

    private IEnumerator DelayAndStopConversation()
    {
        Debug.Log("Zhixing!");
        yield return new WaitForSeconds(waitSeconds);
        DialogueManager.StopConversation();
    }
    
}

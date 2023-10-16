using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class SnakeNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Octopus"))
        {
            QuestLog.SetQuestState("Classroom_TASK_5", QuestState.Abandoned);

            foreach (var item in this.GetComponents<DialogueSystemTrigger>())
            {
                item.OnUse();
            }

            collision.gameObject.SetActive(false);
        }

    }
}

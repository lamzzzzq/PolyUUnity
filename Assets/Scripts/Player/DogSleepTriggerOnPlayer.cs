using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DogSleepTriggerOnPlayer : MonoBehaviour
{
    public bool PlayerLeave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLeave = DialogueLua.GetVariable("TASK_3_4_LEAVE").asBool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            DialogueLua.SetVariable("TASK_3_4_LEAVE",true);
        }
    }
}

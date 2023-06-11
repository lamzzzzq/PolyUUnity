using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialWorkerFixTalk : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueCanvas.activeSelf)
        {
            button.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GameManager: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueLua.SetVariable("AfterSister",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;



public class WashPlateOnPlayer : MonoBehaviour
{
    public int washCount;
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public GameObject mother;

    private bool done = false;
    public Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        washCount = DialogueLua.GetVariable("1_3_Dirt").asInt;
    }

    // Update is called once per frame
    void Update()
    {
        if(washCount == 15)
        {

        }
    }
}

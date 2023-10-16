using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class DrinkKidOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public TeleportPlayerFade teleport;
    public Transform playerPosition;
    public Transform teleportPlayerPosition;
    public GameObject phonePerson;
    public Transform teleportation_firstFloor;
    public PhonePersonOntheGround groundNPC;


    public UnityEvent npcEvents;
    //public GameObject WalletPeople;
    private bool disableMovement = false;
    private CharacterController playerController;

    public GameObject player;
    public GameObject Phone_1;
    public GameObject Phone_2;
    Grabbable grabbable;
    Grabber grabber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

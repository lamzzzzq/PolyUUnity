using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class DrinkKidOnPlayer : MonoBehaviour
{
    /*    public ScreenFader ScreenFader;
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
        Grabber grabber;*/

    public GameObject Lucy;

    // Start is called before the first frame update
    
    public void reachBuutton()
    {
        QuestLog.SetQuestState("Canteen_TASK_5", QuestState.Success);

        foreach (var item in Lucy.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }

    }

    public void pasteOctopus()
    {
        QuestLog.SetQuestState("Canteen_TASK_5", QuestState.Abandoned);

        foreach (var item in Lucy.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;


public class CantennHelper : MonoBehaviour
{
    public GameObject[] gameObjects;

    public GameObject CanteenHelper;

    public TeleportPlayerFade fade;

    public FacePlayerNormal facePlayer;
    private Animator _childAnim;
    //public Animator test;
    private bool objectCounted = false;

    private void Start()
    {
/*        _childAnim = GetComponentInChildren<Animator>();
        if (_childAnim == null)
        {
            Debug.LogWarning("No Animator found in the child GameObjects.");
        }*/
    }

    public void DropFruit()
    {
        //fade.FadeCutscene();
        foreach (var item in gameObjects)
        {
            item.SetActive(true);
        }
    }

    public void TurnToTalk()
    {
        facePlayer.enabled = true;

        //8.13
        //_childAnim.SetBool("Pick", true);

        //test.SetBool("Pick", true);

        //8.13
        //Basket.SetActive(false);
        //BagFloor.SetActive(false);
        //BagHand.SetActive(true);

        //StartConversation();
    }

    public void PlaceItem()
    {
        if (!objectCounted)
        {
            UpdateFruit();
            objectCounted = true;
        }

    }

    public void UpdateFruit()
    {
        int fruit = DialogueLua.GetVariable("3_5_Fruit").asInt;
        fruit++;

        DialogueLua.SetVariable("3_5_Fruit", fruit);
        Debug.Log(fruit);
    }

    public void StartConversation()
    {
        CanteenHelper.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void ResueToHelp()
    {
        DialogueLua.SetVariable("3_5_Detect", true);
    }
}

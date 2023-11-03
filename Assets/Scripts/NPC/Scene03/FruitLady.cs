using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class FruitLady : MonoBehaviour
{
    public GameObject[] gameObjects;

    public GameObject Basket;
    public GameObject BagFloor;
    public GameObject BagHand;
    public GameObject FruitLadyObj;

    public TeleportPlayerFade fade;

    public FacePlayerNormal facePlayer;
    private Animator _childAnim;
    //public Animator test;
    private bool objectCounted = false;

    private void Start()
    {
        _childAnim = GetComponentInChildren<Animator>();
        if (_childAnim == null)
        {
            Debug.LogWarning("No Animator found in the child GameObjects.");
        }
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
        DialogueLua.SetVariable("3_5_OPTION", true);
        facePlayer.enabled = true;
        _childAnim.SetBool("Pick", true);
        //test.SetBool("Pick", true);
        Basket.SetActive(false);
        BagFloor.SetActive(false);
        BagHand.SetActive(true);

        //StartConversation();
    }

    public void PlaceItem()
    {
        if(!objectCounted)
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
        FruitLadyObj.GetComponent<DialogueSystemTrigger>().OnUse();
    }

    public void ResueToHelp()
    {
        DialogueLua.SetVariable("3_5_Detect", true);
        DialogueLua.SetVariable("3_5_OPTION", false);
    }
}

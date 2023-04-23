using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class FruitLady : MonoBehaviour
{
    public GameObject[] gameObjects;
    public FacePlayerNormal facePlayer;
    private Animator _childAnim;
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
        foreach (var item in gameObjects)
        {
            item.SetActive(true);
        }
    }

    public void TurnToTalk()
    {
        facePlayer.enabled = true;
        _childAnim.SetBool("Idle", true);
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
}

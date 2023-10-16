using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class UtensilsLogic : MonoBehaviour
{
    private int boxCount = 0; // 进入触发器的 "Box" 标签物体数量
    public GameObject NPC;
    public TeleportPlayerFade teleportPlayer;
    public Transform playerPosition;
    //public Transform NPCPosition;
    public ScreenFader screenFader;
    public AudioSource audio;
    public AudioClip clip;
    private Animator _anim;

    private void Start()
    {
        _anim = NPC.GetComponent<Animator>();
    }


    private void Update()
    {
        DialogueLua.SetVariable("ProSocial_1.2_Utensils", boxCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 检查进入触发器的物体是否具有 "Box" 标签
        if (other.CompareTag("Box"))
        {
            boxCount++; // 增加计数器

            //audio.PlayOneShot(clip);

            // 当两个物体都进入触发器时
            if (boxCount == 4)
            {
                StartConversationwithPlayer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 检查进入触发器的物体是否具有 "Box" 标签
        if (other.CompareTag("Box"))
        {
            boxCount--;
        }
    }


    private void StartConversationwithPlayer()
    {

        DialogueLua.SetVariable("PlaceUtensils", true);
        //ring.SetActive(false);

        StartCoroutine(ConversationwithPlayer());
    }

    private IEnumerator ConversationwithPlayer()
    {
        yield return new WaitForSeconds(2f);


        //teleport.targetRotation = Quaternion.Euler(rotationDegree);
        teleportPlayer.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        //NPC.transform.position = NPCPosition.position;
        _anim.Play("Idle");
        foreach (var trigger in NPC.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }

    }
}
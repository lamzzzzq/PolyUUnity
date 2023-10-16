using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class UtensilsLogic : MonoBehaviour
{
    private int boxCount = 0; // ���봥������ "Box" ��ǩ��������
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
        // �����봥�����������Ƿ���� "Box" ��ǩ
        if (other.CompareTag("Box"))
        {
            boxCount++; // ���Ӽ�����

            //audio.PlayOneShot(clip);

            // ���������嶼���봥����ʱ
            if (boxCount == 4)
            {
                StartConversationwithPlayer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �����봥�����������Ƿ���� "Box" ��ǩ
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
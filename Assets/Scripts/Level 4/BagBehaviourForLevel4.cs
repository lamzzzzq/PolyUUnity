using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class BagBehaviourForLevel4 : MonoBehaviour
{
    private int boxCount = 0; // ���봥������ "Box" ��ǩ��������
    public GameObject NPC;
    public TeleportPlayerFade teleportPlayer;
    public Transform playerPosition;
    public Transform NPCPosition;
    public ScreenFader screenFader;

    private void Update()
    {
        DialogueLua.SetVariable("4_2_Leaf", boxCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �����봥�����������Ƿ���� "Box" ��ǩ
        if (other.CompareTag("Box"))
        {
            boxCount++; // ���Ӽ�����

            // ���������嶼���봥����ʱ
            if (boxCount == 6)
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

        DialogueLua.SetVariable("CleanDebris", true);
        //ring.SetActive(false);

        StartCoroutine(ConversationwithPlayer());
    }

    private IEnumerator ConversationwithPlayer()
    {
        yield return new WaitForSeconds(2f);


        //teleport.targetRotation = Quaternion.Euler(rotationDegree);
        teleportPlayer.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        NPC.transform.position = NPCPosition.position;

        foreach (var trigger in NPC.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }

    }
}

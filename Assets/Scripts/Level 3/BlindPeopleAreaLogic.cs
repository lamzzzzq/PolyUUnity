using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class BlindPeopleAreaLogic : MonoBehaviour
{
    private int boxCount = 0; // ���봥������ "Box" ��ǩ��������
    public GameObject blindPeople;
    public GameObject ring;
    public TeleportPlayerFade teleport;
    public Transform PlayerPosition;
    public Transform blindPeoplePosition;
    public Vector3 rotationDegree;
    public ScreenFader ScreenFader;

    private void OnTriggerEnter(Collider other)
    {
        // �����봥�����������Ƿ���� "Box" ��ǩ
        if (other.CompareTag("Box"))
        {
            boxCount++; // ���Ӽ�����

            // ���������嶼���봥����ʱ
            if (boxCount == 2)
            {
                StartConversation();
            }
        }
    }

    private void StartConversation()
    {

        DialogueLua.SetVariable("CleanDebris", true);
        //ring.SetActive(false);

        StartCoroutine(Conversation());
    }

    private IEnumerator Conversation()
    {
        yield return new WaitForSeconds(2f);


        //teleport.targetRotation = Quaternion.Euler(rotationDegree);
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);
        blindPeople.transform.position = blindPeoplePosition.position;

        foreach (var trigger in blindPeople.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }

        ring.SetActive(false);
    }

    public void DetectAndAddPoint()
    {
        //Detect how many boxes been put back 
        switch (boxCount)
        {
            case 0:
                Debug.Log("0");
                break;
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
        }
        //Add point for player: 0 -> 0 / 1 -> 15 Points / 2 -> 30 Points

        //Fade In/Out and start conversation with NPC

        DialogueLua.SetVariable("CleanDebris", true);
        //ring.SetActive(false);

        StartCoroutine(Conversation());


    }


}

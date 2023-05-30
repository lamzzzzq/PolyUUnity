using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class MaskLogic : MonoBehaviour
{
    public List<GameObject> maskList;
    private int boxCount = 0; // 进入触发器的 "Box" 标签物体数量
    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public GameObject Customer;
    public Transform PlayerPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactive")
        {

            boxCount++; // 增加计数器

            //Debug.Log("Yes interactive!");
            switch (other.gameObject.name)
            {
                case "TopMask_1":
                    maskList[0].SetActive(true);
                    break;
                case "TopMask_2":
                    maskList[1].SetActive(true);
                    break;
                case "TopMask_3":
                    maskList[2].SetActive(true);
                    break;
                case "TopMask_4":
                    maskList[3].SetActive(true);
                    break;
                case "BottomMask_5":
                    maskList[4].SetActive(true);
                    break;
                case "BottomMask_6":
                    maskList[5].SetActive(true);
                    break;
                default:
                    break;
            }

            // 当计数器为4时触发对话逻辑
            if (boxCount == 4)
            {
                StartConversation();
            }
        }
    }

    private void StartConversation()
    {
        StartCoroutine(Conversation());
    }

    private IEnumerator Conversation()
    {
        yield return new WaitForSeconds(1f);

        //teleport.targetRotation = Quaternion.Euler(rotationDegree);
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);


        foreach (var trigger in Customer.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}

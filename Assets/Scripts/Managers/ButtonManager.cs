using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public GameObject Button;
    private CharacterController playerController;

    private void Start()
    {
        // Find the PlayerController GameObject and get its CharacterController component
        // 查找 PlayerController GameObject 并获取其 CharacterController 组件
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SubPlayer" && !DialogueCanvas.activeSelf)
        {
            Button.SetActive(true);
            playerController.enabled = true;
        }
        else if (other.tag == "SubPlayer" && DialogueCanvas.activeSelf)
        {
            playerController.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SubPlayer")
        {
            Button.SetActive(false);
            playerController.enabled = true;
        }
    }
}

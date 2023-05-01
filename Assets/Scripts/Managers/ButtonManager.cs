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
        if (other.tag == "SubPlayer")
        {
            UpdateButtonState();
            UpdatePlayerControllerState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SubPlayer")
        {
            Button.SetActive(false);
            UpdatePlayerControllerState();
        }
    }

    private void UpdatePlayerControllerState()
    {
        playerController.enabled = !DialogueCanvas.activeSelf;
    }

    private void UpdateButtonState()
    {
        Button.SetActive(!DialogueCanvas.activeSelf);
    }

}

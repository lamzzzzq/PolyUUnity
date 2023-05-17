using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public GameObject Button;
    private CharacterController playerController;

    private float initialRadius;
    private bool isCanvasActive;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();

        // ��ȡ��ʼ��������ײ���뾶
        initialRadius = GetComponent<SphereCollider>().radius;
    }

    private void Update()
    {
        if (Button.activeSelf)
        {
            playerController.enabled = true;
        }
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
        bool newCanvasActiveState = DialogueCanvas.activeSelf;

        // ���Canvas��״̬�Ƿ����仯
        if (isCanvasActive != newCanvasActiveState)
        {
            isCanvasActive = newCanvasActiveState;

            // ����Canvas��״̬����������ײ���뾶
            if (isCanvasActive)
            {
                GetComponent<SphereCollider>().radius = initialRadius * 2f;
            }
            else
            {
                GetComponent<SphereCollider>().radius = initialRadius;
            }
        }

        playerController.enabled = !isCanvasActive;
    }

    private void UpdateButtonState()
    {
        Button.SetActive(!DialogueCanvas.activeSelf);
    }
}

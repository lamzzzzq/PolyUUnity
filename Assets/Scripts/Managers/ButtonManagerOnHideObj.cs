using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ButtonManagerOnHideObj : MonoBehaviour
{
    public GameObject DialogueCanvas;
    public GameObject Button;
    private CharacterController playerController;

    private float initialRadius;
    private bool isCanvasActive;

    private NavMeshAgent agent;
    public GameObject npcObj;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();

        agent = GetComponent<NavMeshAgent>();
        // 获取初始的球形碰撞器半径
        initialRadius = GetComponent<SphereCollider>().radius;
    }

    private void Update()
    {
        if (Button.activeSelf)
        {
            playerController.enabled = true;

            // 检查导航AI的速度是否大于0
            if (agent.velocity.magnitude > 0f)
            {
                Button.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SubPlayer" && npcObj.activeSelf)
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

        // 检查Canvas的状态是否发生变化
        if (isCanvasActive != newCanvasActiveState)
        {
            isCanvasActive = newCanvasActiveState;

            // 根据Canvas的状态设置球形碰撞器半径
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
        Button.SetActive(!DialogueCanvas.activeSelf    );
    }

    public void DisablePlayerMovement()
    {
        playerController.enabled = false;
    }

    public void EnablePlayerMovement()
    {
        playerController.enabled = true;
    }
}

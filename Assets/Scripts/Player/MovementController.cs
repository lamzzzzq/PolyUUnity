using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private CharacterController playerController;

    private void Start()
    {
        // Find the PlayerController GameObject and get its CharacterController component
        // 查找 PlayerController GameObject 并获取其 CharacterController 组件
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void EnableController()
    {
        StartCoroutine(EnablePlayerController());
    }

    private IEnumerator EnablePlayerController()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("ye");
        playerController.enabled = true;
    }
}

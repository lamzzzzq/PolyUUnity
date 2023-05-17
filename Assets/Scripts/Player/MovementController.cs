using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private CharacterController playerController;

    private void Start()
    {
        // Find the PlayerController GameObject and get its CharacterController component
        // ���� PlayerController GameObject ����ȡ�� CharacterController ���
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

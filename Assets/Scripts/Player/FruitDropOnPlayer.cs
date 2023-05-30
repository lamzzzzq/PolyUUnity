using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class FruitDropOnPlayer : MonoBehaviour
{
    public ScreenFader ScreenFader;
    public Vector3 rotationDegree_1;
    public Transform playerPosition;

    public TeleportPlayerFade teleport;

    public GameObject FruitCanvas;

    public UnityEvent npcEvents;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void FruitDropCutSceneFirst()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1);
        teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        StartCoroutine(invokeFruitEvent());
        playerController.enabled = false;
    }

    private IEnumerator invokeFruitEvent()
    {
        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
        yield return new WaitForSeconds(1f);
        FruitCanvas.SetActive(true);
    }
}

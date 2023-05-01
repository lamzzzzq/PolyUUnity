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

    public UnityEvent npcEvents;

    private CharacterController playerController;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void FruitDropCutScene()
    {
        teleport.targetRotation = Quaternion.Euler(rotationDegree_1) * transform.rotation;
        teleport.ResetPlayerPosRotWithParameters(playerPosition, ScreenFader);
        StartCoroutine(invokeFruitEvent());
    }

    private IEnumerator invokeFruitEvent()
    {
        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
    }
}

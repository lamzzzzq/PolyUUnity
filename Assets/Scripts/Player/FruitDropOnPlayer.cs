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

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<CharacterController>();
    }

    public void FruitDropCutSceneFirst()
    {
        //teleport.targetRotation = Quaternion.Euler(rotationDegree_1);
        //teleport.ResetPlayerPosRotWithParameters(transform, ScreenFader);
        StartCoroutine(invokeFruitEvent());
        playerController.enabled = false;
    }

    private IEnumerator invokeFruitEvent()
    {
        Debug.Log("Execute");


        yield return new WaitForSeconds(1f);
        npcEvents.Invoke();
        yield return new WaitForSeconds(2f);
        //Play audio clip
        audioSource.PlayOneShot(audioClip);
        FruitCanvas.SetActive(true);
        StartCoroutine(PlayAudioAndEnableButton());
    }

    private IEnumerator PlayAudioAndEnableButton()
    {
        yield return new WaitForSeconds(audioClip.length);
        SetButtonsInteractable(true);
    }

    private void SetButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] buttons = FruitCanvas.GetComponentsInChildren<UnityEngine.UI.Button>(true);

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

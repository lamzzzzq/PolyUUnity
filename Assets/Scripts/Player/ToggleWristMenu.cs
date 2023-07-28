using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class ToggleWristMenu : MonoBehaviour
{
    public GameObject WristMenu;
    public bool Show;
    private bool isButtonPressed = false;
    private float buttonPressStartTime = 0f;
    private float holdDuration = 2f;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.M) || InputBridge.Instance.XButtonDown) && !isButtonPressed)
        {
            isButtonPressed = true;
            buttonPressStartTime = Time.time;
        }

        if ((Input.GetKeyUp(KeyCode.M) || InputBridge.Instance.XButtonUp) && isButtonPressed)
        {
            isButtonPressed = false;

            float buttonHoldTime = Time.time - buttonPressStartTime;
            if (buttonHoldTime >= holdDuration)
            {
                Show = !Show;
            }
        }

        WristMenu.SetActive(Show);
    }

}

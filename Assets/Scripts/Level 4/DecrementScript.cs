using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DecrementScript : MonoBehaviour
{
    public TMP_Text numberText;
    public UnityEvent onNumberSeven;
    public UnityEvent onNumberFour;
    public UnityEvent onNumberZero;
    //public GameObject particleSystem;
    public GameObject canvas;
    //public GameObject exitBtn;
    public GameObject gunBoy;
    private GunBoy gunBoyScript;
    public ParticleSystem particleSystem;


    public float cooldownDuration = 0.5f;
    private float lastPressTime;


    public bool isNPCMoving = false;

    private void Start()
    {
/*        Button decrementButton = GetComponent<Button>();
        decrementButton.onClick.AddListener(DecrementNumber);*/
        gunBoyScript = gunBoy.GetComponent<GunBoy>();
    }

    public void DecrementNumber()
    {
        // Check if enough time has passed since the last button press
        if (Time.time - lastPressTime < cooldownDuration)
        {
            return; // Ignore the button press
        }

        lastPressTime = Time.time; // Record the current press time



        string numberString = numberText.text;
        if (int.TryParse(numberString, out int currentNumber))
        {
            if(!isNPCMoving && currentNumber > 0)
            {
                if (currentNumber == 7 || currentNumber == 4 || currentNumber == 1)
                {
                    // Do not play the particle system
                }
                else
                {
                    // Play the particle system
                    particleSystem.Play();
                }

                if (currentNumber == 7)
                {
                    Debug.Log("Current Number is:" + currentNumber);
                    Debug.Log("gunboyScript Enabled");
                    onNumberSeven.Invoke();
                    //particleSystem.SetActive(false);
                    //exitBtn.SetActive(true);
                    Debug.Log("Show2");
                }
                if (currentNumber == 4)
                {
                    onNumberFour.Invoke();
                }
                if(currentNumber == 1)
                {
                    Debug.Log("Exe");
                    onNumberZero.Invoke();
                }
                currentNumber--;
                numberText.text = currentNumber.ToString();
            }
        }
        else
        {
            Debug.LogError("Invalid number in UI Text element.");
        }
    }

    public void hideUI()
    {
        canvas.SetActive(false);
    }

    public void showUI()
    {
        canvas.SetActive(true);
    }
}


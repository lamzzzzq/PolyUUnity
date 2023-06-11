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
    //public GameObject particleSystem;
    public GameObject canvas;
    //public GameObject exitBtn;
    public GameObject gunBoy;
    private GunBoy gunBoyScript;

    private void Start()
    {
/*        Button decrementButton = GetComponent<Button>();
        decrementButton.onClick.AddListener(DecrementNumber);*/
        gunBoyScript = gunBoy.GetComponent<GunBoy>();
    }

    public void DecrementNumber()
    {
        string numberString = numberText.text;
        if (int.TryParse(numberString, out int currentNumber))
        {
            if (currentNumber == 7)
            {
                Debug.Log("Current Number is:" + currentNumber);

                Debug.Log("gunboyScript Enabled");
                onNumberSeven.Invoke();
                //particleSystem.SetActive(false);
                //exitBtn.SetActive(true);
                currentNumber--;
                Debug.Log("Show2");
            }
            if(currentNumber ==4)
            {
                onNumberFour.Invoke();

                //particleSystem.SetActive(false);
            }
            currentNumber--;
            numberText.text = currentNumber.ToString();
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


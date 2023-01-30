using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DecrementScript : MonoBehaviour
{
    public TMP_Text numberText;
    public UnityEvent onNumberFive;
    public GameObject particleSystem;
    public GameObject canvas;
    public GameObject exitBtn;

    private void Start()
    {
        Button decrementButton = GetComponent<Button>();
        decrementButton.onClick.AddListener(DecrementNumber);
    }

    public void DecrementNumber()
    {
        string numberString = numberText.text;
        if (int.TryParse(numberString, out int currentNumber))
        {
            if (currentNumber == 5)
            {
                onNumberFive.Invoke();
                particleSystem.SetActive(false);
                exitBtn.SetActive(true);
                return;
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

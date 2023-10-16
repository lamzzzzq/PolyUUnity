using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4SaveButton : MonoBehaviour
{
    public void SaveButton()
    {
        // Call SaveOnKeyPress() from the MainManager instance
        if (MainManager.Instance != null)
        {
            //MainManager.Instance.SaveOnKeyPress();
        }
        else
        {
            Debug.LogError("MainManager instance not found.");
        }
    }
}

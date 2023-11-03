using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControllerWhenWelcomePanel : MonoBehaviour
{
    public CharacterController playerController;
    private bool hasExecuted = false;

    // This function will be called every time the GameObject is disabled
    void OnDisable()
    {
        if (!hasExecuted)
        {
            // Call your function here
            MyFunction();

            // Set the flag so that the function won't be called again
            hasExecuted = true;
        }
    }

    private void MyFunction()
    {
        // Your custom logic here
        playerController.enabled = true;
    }

    // Call this method to reset the execution flag if needed
    public void ResetExecution()
    {
        hasExecuted = false;
    }
}

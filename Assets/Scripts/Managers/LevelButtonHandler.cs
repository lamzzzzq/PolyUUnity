using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonHandler : MonoBehaviour
{
    public List<Button> LevelButtons;
    public string[] SceneNames;

    void Start()
    {
        // Get the current scene index
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < LevelButtons.Count; i++)
        {
            Button levelButton = LevelButtons[i];

            // If the button index matches the current scene index, disable the button
            if (i == currentSceneIndex - 1)
            {
                levelButton.interactable = false;
                continue;
            }

            string sceneName = SceneNames[i];
            levelButton.onClick.AddListener(() => MainManager.Instance.OnButtonClick(sceneName));
        }
    }

    public void UpdateButtons()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        for (int i = 0; i < LevelButtons.Count; i++)
        {
            Button levelButton = LevelButtons[i];

            if (i == currentSceneIndex - 1)
            {
                levelButton.interactable = false;
            }
            else
            {
                levelButton.interactable = true;
            }
        }
    }

}

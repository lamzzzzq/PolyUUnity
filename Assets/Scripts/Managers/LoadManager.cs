using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    //public GameObject loadScreen;
    public Slider slider;
    public Text text;

    public void LoadNextLevel(string scene)
    {
        StartCoroutine(Loadlevel(scene));
    }


    IEnumerator Loadlevel(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            slider.value = operation.progress;

            text.text = operation.progress * 100 + "%";

            if(operation.progress >= 0.9f)
            {
                slider.value = 1;

                operation.allowSceneActivation = true;

            }

            yield return null;
        }
    }
}

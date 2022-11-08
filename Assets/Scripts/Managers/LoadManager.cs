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

        float progress = 0;

        while(!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);

            slider.value = progress;

            text.text = progress * 100 + "%";

            if( progress >= 0.9f)
            {
                slider.value = 1;

                operation.allowSceneActivation = true;

            }

            yield return null;
        }
    }
}

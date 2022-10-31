using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;


/*    public void MoveToScene(string scene)
    {
        Debug.Log("Clicked to MoveScene");

        StartCoroutine(GoToSceneRoutine(scene));
        //SceneManager.LoadScene(sceneID);
    }


    IEnumerator GoToSceneRoutine(string scene)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);  

        PixelCrushers.SaveSystem.LoadScene(scene);
    }*/


    public void MoveToSceneAsync(string scene)
    {
        Debug.Log("Clicked to MoveScene");

        StartCoroutine(GoToSceneAsyncRoutine(scene));
        //SceneManager.LoadScene(sceneID);
    }


    IEnumerator GoToSceneAsyncRoutine(string scene)
    {
        fadeScreen.FadeOut();


        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;

            Debug.Log(operation.progress);
            yield return null;
        }

        //operation.allowSceneActivation = true;
    }
}

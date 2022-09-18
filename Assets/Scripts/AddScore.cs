using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddScore : MonoBehaviour
{
    Scene scene;

    public Text Point;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene name is" + scene.name + "\n Active Scene index:" + scene.buildIndex);
    }

    void Update()
    {
/*        int value = DialogueLua.GetVariable("Point").asInt;

        Point.text = value.ToString();*/


        switch(scene.buildIndex)
        {
            case 1:
                {
                    int value = DialogueLua.GetVariable("Point_Level").asInt;

                    Point.text = value.ToString();
                }
                break;
            case 2:
                {
                    int value = DialogueLua.GetVariable("Point_Level2").asInt;

                    Point.text = value.ToString();
                }
                break;
            default:
                Debug.Log("¦bwelcome scene");
                break;

        }
    }
}

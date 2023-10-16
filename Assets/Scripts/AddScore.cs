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
                    int value = DialogueLua.GetVariable("Point/Level_1").asInt;

                    Point.text = value.ToString();
                }
                break;
            case 2:
                {
                    //Debug.Log("在scene 2");
                    int value = DialogueLua.GetVariable("Point/Level_2").asInt;

                    Point.text = value.ToString();
                }
                break;
            case 3:
                {
                    //Debug.Log("在scene 3");
                    int value = DialogueLua.GetVariable("Point/Level_3").asInt;

                    Point.text = value.ToString();
                }
                break;

            case 4:
                {
                    //Debug.Log("在scene 4");
                    int value = DialogueLua.GetVariable("Point/Level_4").asInt;

                    Point.text = value.ToString();
                }
                break;

            case 5:
                {
                    //Debug.Log("在scene 4");
                    int value = DialogueLua.GetVariable("Point/Level_5").asInt;

                    Point.text = value.ToString();
                }
                break;

            case 7:
                {
                    //Debug.Log("在scene 4");
                    int value = DialogueLua.GetVariable("Point/Canteen").asInt;

                    Point.text = value.ToString();
                }
                break;

            case 8:
                {
                    //Debug.Log("在scene 4");
                    int value = DialogueLua.GetVariable("Point/Classroom").asInt;

                    Point.text = value.ToString();
                }
                break;



            default:
                //Debug.Log("在welcome scene");
                break;

        }
    }
}

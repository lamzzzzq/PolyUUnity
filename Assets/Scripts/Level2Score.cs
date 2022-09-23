using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class Level2Score : MonoBehaviour
{
    public Text Point;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int value = DialogueLua.GetVariable("Point_Level2").asInt;

        Point.text = value.ToString();
    }
}

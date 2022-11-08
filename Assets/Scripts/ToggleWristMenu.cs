using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ToggleWristMenu : MonoBehaviour
{

    public GameObject WristMenu;
    public bool Show;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.M)) || (InputBridge.Instance.XButtonDown))
        {
            Show = !Show;
        }

        if(Show)
        {
            WristMenu.SetActive(true);
        }

        if(!Show)
        {
            WristMenu.SetActive(false);
        }
    }
}

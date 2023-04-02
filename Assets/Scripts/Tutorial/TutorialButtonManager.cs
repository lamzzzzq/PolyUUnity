using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class TutorialButtonManager : MonoBehaviour
{
    void Update()
    {
        if((InputBridge.Instance.LeftThumbstick) && (InputBridge.Instance.RightThumbstick))
        {
            Debug.Log("Hehe");
        }
    }
}

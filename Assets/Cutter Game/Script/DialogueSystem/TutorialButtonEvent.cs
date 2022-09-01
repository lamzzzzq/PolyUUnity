using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonEvent : MonoBehaviour
{

    public PopUpUI popUpUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBool()
    {
        popUpUI.isOtherOperation = true;
    }
}

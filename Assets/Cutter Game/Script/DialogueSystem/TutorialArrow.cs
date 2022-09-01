using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{
    public GameObject arrow;
    public PopUpUI popUpUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowArrow();
    }


    public void ShowArrow()
    {
        if(popUpUI.index == 5)
        {
            arrow.SetActive(true);
            arrow.transform.localPosition = new Vector3(216.1f,-1.1f,-259.4f);
        }

        if(popUpUI.index == 6)
        {
            arrow.SetActive(true);
            arrow.transform.localPosition = new Vector3(121f, -1.1f, -259.4f);
        }

        if (popUpUI.index == 7)
        {
            arrow.SetActive(true);
            arrow.transform.localPosition = new Vector3(23f, -1.1f, -259.4f);
        }
    }
}

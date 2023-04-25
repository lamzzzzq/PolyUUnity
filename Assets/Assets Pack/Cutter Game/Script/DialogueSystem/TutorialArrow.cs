using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialArrow : MonoBehaviour
{
    public GameObject arrow0;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;

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
            arrow0.SetActive(true);
            
        }

        if(popUpUI.index == 6)
        {
            arrow1.SetActive(true);
            arrow0.SetActive(false);
            
        }

        if (popUpUI.index == 7)
        {
            arrow2.SetActive(true);
            arrow1.SetActive(false);
        }
    }
}

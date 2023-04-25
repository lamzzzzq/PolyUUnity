using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialButtonEvent : MonoBehaviour
{

    public PopUpUI popUpUI;
    public Button addButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = addButton.GetComponent<Button>();
        //btn.onClick.AddListener(updateIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBool()
    {
        popUpUI.isOtherOperation = true;
    }

    public void updateIndex()
    {
        popUpUI.textLable.text = popUpUI.textList[popUpUI.index];
    }
}   

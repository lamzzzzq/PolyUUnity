using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class SetZHHK : MonoBehaviour
{
    //test 1
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        DialogueManager.SetLanguage("zh-Hans");
        Debug.Log("Set-zh-HansWritten");
    }
}

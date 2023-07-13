using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonSwitch : MonoBehaviour
{
    public GameObject guide;
    public GameObject menu;
    public bool menuActive = true;
    public TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    public void ButtonClicked()
    {
        menu.SetActive(menuActive);
        guide.SetActive(!menuActive);
        //buttonText.text = menuActive ? "MENU" : "GUIDE";
        menuActive = !menuActive;
    }
}

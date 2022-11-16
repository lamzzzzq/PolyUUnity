using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    public GameObject guide;
    public GameObject menu;
    public bool isEnabled = true;
    // Start is called before the first frame update
    public void ButtonClicked()
    {
        isEnabled = !isEnabled;

        guide.SetActive(isEnabled);
        menu.SetActive(!isEnabled);
    }
}

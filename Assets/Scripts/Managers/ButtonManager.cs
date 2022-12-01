using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject DialogueCanvas;
    public GameObject Button;
    // Start is called before the first frame update


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SubPlayer" && !DialogueCanvas.activeSelf)
        {
            Button.SetActive(true);
            //Debug.Log("That's right button true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SubPlayer")
        {
            Button.SetActive(false);
            //Debug.Log("ButtonFalse");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowZoomIn : MonoBehaviour
{
    public GameObject PaitingZoomIn;
    public GameObject ZoomInButton;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "SubPlayer" && !PaitingZoomIn.activeSelf)
        {
            ZoomInButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SubPlayer")
        {
            ZoomInButton.SetActive(false);
        }
    }

}

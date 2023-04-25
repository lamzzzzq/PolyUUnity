using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMainCamera : MonoBehaviour
{

    private GameObject container;

    // Start is called before the first frame update
    void Start()
    {

        Canvas canvas = GetComponent<Canvas>();

        container = GameObject.Find("CenterEyeAnchor");

        canvas.worldCamera = container.GetComponent<Camera>();
    }


}

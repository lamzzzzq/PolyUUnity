using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpArrow : MonoBehaviour
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
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && arrow.activeSelf)
        {
            popUpUI.isOtherOperation = true;
        }



    }
}

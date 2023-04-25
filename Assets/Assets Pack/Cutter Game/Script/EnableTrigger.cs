 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrigger : MonoBehaviour
{
    [SerializeField] GameObject button;
    Collider buttonCollider;



    void Start()
    {
        buttonCollider = button.GetComponent<Collider>();
        buttonCollider.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonCollider.enabled = true;
        }
    }
}

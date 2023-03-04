using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject trigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SubPlayer")
        {
            trigger.SetActive(true);
        }
    }
}

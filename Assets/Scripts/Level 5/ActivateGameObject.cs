using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject trigger;

    public FacePlayerNormal facePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SubPlayer")
        {
            trigger.SetActive(true);
            facePlayer.enabled = true;
        }
    }
}

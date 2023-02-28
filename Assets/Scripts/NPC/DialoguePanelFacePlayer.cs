using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialoguePanelFacePlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        //transform.localRotation = Quaternion.identity;
        transform.LookAt(player.transform, Vector3.up);
        transform.Rotate(0, -180, 0);
    }
}


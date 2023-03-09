using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using BNG;

public class TeleportationPosition : MonoBehaviour
{
    public GameObject target;
    public GameObject exitPosition;
    public GameObject player;
    public GameObject confirmUI;
    // Start is called before the first frame update
    
    public void teleportationPosition()
    {
        player.transform.position = target.transform.position;
    }

    public void DisableMovement()
    {
        player.GetComponent<CharacterController>().enabled = false;
    }

    public void ExitJet()
    {
        player.transform.position = exitPosition.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void DisableConfirmUI()
    {
        Destroy(confirmUI);
    }
}

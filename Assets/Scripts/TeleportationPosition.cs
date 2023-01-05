using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPosition : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    // Start is called before the first frame update
    
    public void teleportationPosition()
    {
        player.transform.position = target.transform.position;
    }
}

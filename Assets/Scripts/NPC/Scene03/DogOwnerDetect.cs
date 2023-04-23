using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOwnerDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            Debug.Log("CHANGE TARGET TO DOG");
        }
    }
}

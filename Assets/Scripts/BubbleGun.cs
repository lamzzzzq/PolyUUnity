using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BubbleGun : MonoBehaviour
{
    public UnityEvent onShootEvent;

    private void Update()
    {
        if (onShootEvent != null)
        {
            onShootEvent.Invoke();
        }
    }

    public void Shoot()
    {
        if(Input.GetKey(KeyCode.O))
        {
            Debug.Log("That's right!");
        }
    }

}

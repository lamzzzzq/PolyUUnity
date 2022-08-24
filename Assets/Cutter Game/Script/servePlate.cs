using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;


public class servePlate : MonoBehaviour
{
    [SerializeField] private bool rightMeal = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && (Input.GetKeyDown(KeyCode.I)||InputBridge.Instance.BButtonDown))
        {
            Debug.Log("plateValue = " + GameFlow.plateValue[GameFlow.plateNum]);
            Debug.Log("orderValue = " + GameFlow.orderValue[GameFlow.plateNum]);
            if(GameFlow.plateValue[GameFlow.plateNum] == GameFlow.orderValue[GameFlow.plateNum])
            {
                rightMeal = true;
                PixelCrushers.MessageSystem.SendMessage(this,"Got","Sandwich");
            }else
            {
                PixelCrushers.MessageSystem.SendMessage(this,"Got","FakeSandwich");
            }

        }
        
    }
}

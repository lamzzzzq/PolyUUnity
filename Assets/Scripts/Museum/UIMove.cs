using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class UIMove : MonoBehaviour
{
    public bool moveXY;
    public bool isOccupied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzlePiece")
        {
            isOccupied = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (InputBridge.Instance.RightTrigger > 0 && isOccupied)
        {
            if (moveXY)
            {
                other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
            }
            else if (!moveXY)
            {
                other.transform.position = transform.position;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PuzzlePiece")
        {
            isOccupied = false;
        }
    }
}
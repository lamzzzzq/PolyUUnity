using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskLogic : MonoBehaviour
{
    public List<GameObject> maskList;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactive")
        {
            //Debug.Log("Yes interactive!");
            switch(other.gameObject.name)
            {
                case "TopMask_1":
                    maskList[0].SetActive(true);
                    break;
                case "TopMask_2":
                    maskList[1].SetActive(true);
                    break;
                case "TopMask_3":
                    maskList[2].SetActive(true);
                    break;
                case "TopMask_4":
                    maskList[3].SetActive(true);
                    break;
                case "BottomMask_5":
                    maskList[4].SetActive(true);
                    break;
                case "BottomMask_6":
                    maskList[5].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}

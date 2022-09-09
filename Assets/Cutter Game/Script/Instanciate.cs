using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Instanciate : MonoBehaviour
{
    //public Transform genPoint;
    public Transform cloneObj;
    public int foodValue;
    //public GameObject UIObject;
    public PopUpUI popUpUI;




    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.tag == "Player")
    //     {   
    //         if(Input.GetKeyDown(KeyCode.J))
    //         {
    //         Instantiate(cloneObj, new Vector3(10.95f,0.3f,26.49f), cloneObj.rotation);
    //         Debug.Log("Instantiate Burger");
    //         }
    //     }



/*    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            if (gameObject.name == "BreadTop" && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
            {
                Instantiate(cloneObj, new Vector3(10.974f, 0.3f, GameFlow.plateZpos), Quaternion.identity);
                Debug.Log("Instantiate Burger Top");
                GameFlow.plateValue[GameFlow.plateNum] += foodValue;
            }
            if (gameObject.name == "Cheese" && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
            {
                Instantiate(cloneObj, new Vector3(10.974f, 0.20f, GameFlow.plateZpos), Quaternion.identity);
                //newCheese.transform.parent = testObj.transform;
                Debug.Log("Instantiate CheeseSlice");
                GameFlow.plateValue[GameFlow.plateNum] += foodValue;
            }
            if (gameObject.name == "Tomato" && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
            {
                Instantiate(cloneObj, new Vector3(10.974f, 0.12f, GameFlow.plateZpos), Quaternion.identity);
                //newTomato.transform.parent = testObj.transform;
                Debug.Log("Instantiate TomatoSlice");
                GameFlow.plateValue[GameFlow.plateNum] += foodValue;
            }
            if (gameObject.name == "BreadBottom" && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
            {
                Instantiate(cloneObj, new Vector3(10.974f, 0.1f, GameFlow.plateZpos), Quaternion.identity);
                //newBreadBottom.transform.parent = testObj.transform;
                Debug.Log("Instantiate Burger Bottom");
                GameFlow.plateValue[GameFlow.plateNum] += foodValue;
            }


            if (Input.GetKeyDown(KeyCode.P))
            { Debug.Log(GameFlow.plateValue[GameFlow.plateNum] + " " + GameFlow.orderValue[GameFlow.plateNum]); }
        }


    }*/
    public void instantiateTopBred()
    {

        Instantiate(cloneObj, new Vector3(10.974f, 0.3f, GameFlow.plateZpos), Quaternion.identity);
        Debug.Log("Instantiate Burger Top");
        GameFlow.plateValue[GameFlow.plateNum] += foodValue;

    }
    public void instantiateMeatSlice()
    {

        Instantiate(cloneObj);
        Debug.Log("Move LunchMeatSlice");

    }
    public void instantiateCheese()
    {

        Instantiate(cloneObj, new Vector3(10.974f, 0.20f, GameFlow.plateZpos), Quaternion.identity);
        Debug.Log("Instantiate Cheese");
        GameFlow.plateValue[GameFlow.plateNum] += foodValue;

    }
    public void instantiateTomato()
    {

        Instantiate(cloneObj, new Vector3(10.974f, 0.12f, GameFlow.plateZpos), Quaternion.identity);
        Debug.Log("Instantiate Tomato");
        GameFlow.plateValue[GameFlow.plateNum] += foodValue;

    }
    public void instantiateBredBottom()
    {

        Instantiate(cloneObj, new Vector3(10.974f, 0.1f, GameFlow.plateZpos), Quaternion.identity);
        Debug.Log("Instantiate Burger Bottom");
        GameFlow.plateValue[GameFlow.plateNum] += foodValue;
        popUpUI.isOtherOperation = true;

    }


}





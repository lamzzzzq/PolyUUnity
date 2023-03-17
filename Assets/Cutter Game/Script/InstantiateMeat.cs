using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMeat : MonoBehaviour
{
    public GameObject cookedMeat;
    //public int foodValue = 0;
    public PopUpUI popUpUI;

    private GameObject addButton;
    private GameObject parentButton;
    
    public GameObject instantiatedMeat;
    [SerializeField]
    private MoveCookedMeat movecookedmeat;

    // Start is called before the first frame update
    void Start()
    {
        movecookedmeat = GameObject.Find("LunchMeatSliceToInstantiate(Clone)").GetComponent<MoveCookedMeat>();
        parentButton = GameObject.Find("Button Group");
        addButton = parentButton.transform.Find("MeatAddButton").gameObject;

    }



    public void MoveMeat()
    {

/*        Instantiate(cookedMeat, new Vector3(10.974f, 0.26f, GameFlow.plateZpos), Quaternion.identity);
        GameFlow.plateValue[GameFlow.plateNum] += movecookedmeat.foodValue;*/
        //movecookedmeat.cooking = false;
        //meatMat.material.color = defaultColor;
        //GameObject.Find("LunchMeatSlice").SetActive(false); //meatBaking in MeatSlice.cs
        //Debug.Log(movecookedmeat.cooking);


        addButton.SetActive(false);
        popUpUI.isOtherOperation = true;
    }
}

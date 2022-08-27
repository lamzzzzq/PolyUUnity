using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateButton : MonoBehaviour
{
    public GameObject cookedMeat;


    private MoveCookedMeat movecookedmeat;

    // Start is called before the first frame update
    void Start()
    {
        movecookedmeat = GameObject.Find("LunchMeatSliceToInstantiate").GetComponent<MoveCookedMeat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateCookedMeat()
    {

        Instantiate(cookedMeat, new Vector3(10.974f, 0.26f, GameFlow.plateZpos), Quaternion.identity);
        GameFlow.plateValue[GameFlow.plateNum] += movecookedmeat.foodValue;
        movecookedmeat.cooking = false;
        //meatMat.material.color = defaultColor;
        //GameObject.Find("LunchMeatSlice").SetActive(false); //meatBaking in MeatSlice.cs
        //Destroy(gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class MoveCookedMeat : MonoBehaviour
{

    public AudioSource audioData;
    private ParticleSystem ps;
    public int foodValue = 0;
    private MeshRenderer meatMat;
    public bool cooking = true;


    public GameObject cookedMeat;

    GameObject parentButton;
    public GameObject addButton;

    //
    public Color colorToTurnTo;
    //public Color defaultColor;


    // Start is called before the first frame update
    void Start()
    {   
        audioData = GetComponent<AudioSource>();
        
        meatMat = GetComponent<MeshRenderer>();

        parentButton = GameObject.Find("Button Group");

        //addButton = GameObject.Find("MeatAddButton");
        StartCoroutine(cookTimer());


        //activate an inactivate GameObject, this is not the best way
        addButton = parentButton.transform.Find("MeatAddButton").gameObject;     
        

        ps = GameObject.Find("_meatPar").GetComponent<ParticleSystem>();
        ps.Play();
        
    }

    /*    private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.J) || InputBridge.Instance.BButtonDown))
            {
                Instantiate(cookedMeat, new Vector3(10.974f, 0.26f, GameFlow.plateZpos), Quaternion.identity);
                GameFlow.plateValue[GameFlow.plateNum] += foodValue;
                cooking = false;
                //meatMat.material.color = defaultColor;
                //GameObject.Find("LunchMeatSlice").SetActive(false); //meatBaking in MeatSlice.cs
                Destroy(gameObject);
            }
        }*/


    IEnumerator cookTimer()
    {
        yield return new WaitForSeconds(10);
        
        foodValue = 1000;
        addButton.SetActive(true);
        if(cooking == true)
        {   
            audioData.Play();
            meatMat.material.color = colorToTurnTo;
            ps.Pause();
            ps.Clear();
        }

    }
}

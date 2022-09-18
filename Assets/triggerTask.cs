using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTask : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject books;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Basketball")
        {
            obj1.SetActive(false);
            obj2.SetActive(false) ;

            books.SetActive(true);

        }    
       
    }
}

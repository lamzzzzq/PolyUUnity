using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTask : MonoBehaviour
{
    public List<GameObject> gameObject = new List<GameObject>();

    public Transform shakePoint;
    public Transform spawnPoint;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject books;
    public GameObject file;
    public GameObject pen;

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ShakePoint")
        {
            anim.enabled = true;
        }



        if(other.gameObject.name == "DropPoint")
        {
            obj1.SetActive(false);
            obj2.SetActive(false) ;

            for (int i = 0; i < gameObject.Count; i++)
            {
                Instantiate(gameObject[i], spawnPoint.transform.position, Quaternion.identity);
            }


        }    
       
    }
}

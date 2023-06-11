using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTask : MonoBehaviour
{
    public List<GameObject> gameObject = new List<GameObject>();

    public AddForce addForce;

    public Transform shakePoint;
    public Transform spawnPoint;
    public GameObject cube;

    public List<Animator> anim = new List<Animator>();
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ShakePoint")
        {
            for(int i = 0; i < anim.Count; i++)
            {
                anim[i].enabled = true;
            }
        }

        if(other.gameObject.name == "DropPoint")
        {
            //obj1.SetActive(false);
            //obj2.SetActive(false) ;

            for (int i = 0; i < gameObject.Count; i++)
            {
                Instantiate(gameObject[i], spawnPoint.transform.position, Quaternion.identity);
            }

            cube.SetActive(true);
            addForce.enabled = true;

            Debug.Log("Drop");
        }    
       
    }
}

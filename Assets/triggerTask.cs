using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTask : MonoBehaviour
{
    private Animator _anim;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject books;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Basketball")
        {
            _anim.SetTrigger("Idle");
            obj1.SetActive(false);
            obj2.SetActive(false) ;

            books.SetActive(true);

        }    
       
    }
}

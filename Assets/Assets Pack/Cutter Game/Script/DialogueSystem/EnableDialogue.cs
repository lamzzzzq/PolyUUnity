using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {


        dialogue.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !dialogue.activeSelf)
        {
            dialogue.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooker : MonoBehaviour
{
    public int Score = 0;
    public Text text;

    public int Menu;
    public bool cooked = false;

    public GameObject tagText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = Score.ToString();
        if(Score == Menu)
        {
            cooked = true;
            tagText.GetComponent<Text>().color = Color.green;
        }
        else
        {
            cooked = false;
            tagText.GetComponent<Text>().color = Color.white;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bread"))
        {
            Score = Score + 1000;
        }
        
        if(other.CompareTag("Meat"))
        {
            Score = Score + 100;
        }

        if (other.CompareTag("Tomato"))
        {
            Score = Score + 10;
        }

        if (other.CompareTag("Cheese"))
        {
            Score = Score + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bread"))
        {
            Score = Score - 1000;
            Debug.Log(Score);
        }

        if (other.CompareTag("Meat"))
        {
            Score = Score - 100;
            Debug.Log(Score);
        }

        if (other.CompareTag("Tomato"))
        {
            Score = Score - 10;
            Debug.Log(Score);
        }

        if (other.CompareTag("Cheese"))
        {
            Score = Score - 1;
            Debug.Log(Score);
        }
    }
}

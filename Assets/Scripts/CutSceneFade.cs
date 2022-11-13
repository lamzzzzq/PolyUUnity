using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneFade : MonoBehaviour
{
    public bool fadeoutin = true; 
    public float fadeSpeed; 
    IEnumerator FadeInObject()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color; 
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime); 
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor; 
            yield return null;
        }
    }
    IEnumerator FadeOutObject()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color; 
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime); 
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor; 
            yield return null;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && fadeoutin == true)
        {
            fadeoutin = false;
            StartCoroutine(FadeOutObject());
        }
        if (Input.GetKeyDown(KeyCode.I) && fadeoutin == false)
        {
            fadeoutin = true;
            StartCoroutine(FadeInObject());
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFadeIn : MonoBehaviour
{
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f<= 1; f+=0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFading()
    {
        //Debug.Log("Yes");
        StartCoroutine("FadeIn");


    }
}

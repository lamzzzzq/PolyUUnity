using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFadeInExecute : MonoBehaviour
{
    public List<GameObject> gameObject = new List<GameObject>();
    public bool waterPoured = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SubPlayer")&& (waterPoured == false) )
        {
            for (int i = 0; i < gameObject.Count; i++)
            {
                gameObject[i].GetComponent<WaterFadeIn>().StartFading();
            }
            waterPoured = true;
        }
    }
}

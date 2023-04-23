using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class YourScript : MonoBehaviour
{
    public FruitLady fruit;
    private HashSet<GameObject> countedObjects = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!countedObjects.Contains(other.gameObject))
        {
            fruit.UpdateFruit();
            countedObjects.Add(other.gameObject);
        }
    }
}

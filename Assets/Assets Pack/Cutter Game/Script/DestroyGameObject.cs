using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject toDestroy;

    public void DestroyIt()
    {
        Destroy(toDestroy);
    }
}

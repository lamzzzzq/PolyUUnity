using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFindRope : MonoBehaviour
{
    public GameObject npcHand;
    // Start is called before the first frame update
    void Start()
    {
        Transform endRope = transform.GetChild(0).GetChild(0);
        if (endRope != null)
        {
            npcHand.transform.SetParent(endRope);
            npcHand.transform.localPosition = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

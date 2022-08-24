using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static int[] orderValue = {12101,10111,11101,11111 };
    public static int[] plateValue = {00000,00000,00000,00000 };

    public static int plateNum = 0;
    public static float plateZpos = 25.8f;

    public Transform plateSelector;

    //public MeshRenderer[] currentPic;

    //public Texture[] orderPic;

    // Start is called before the first frame update
    void Start()
    {
        //just a test
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            plateNum += 1;
            plateZpos += 0.23f;

            if(plateNum >3)
            {
                plateNum = 0;
                plateZpos = 25.8f;
            }

            plateSelector.transform.position = new Vector3(10.975f, 0.023f, plateZpos);
        }
    }
}

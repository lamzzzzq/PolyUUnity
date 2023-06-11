using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class GameFlow : MonoBehaviour
{
    /*    public static int[] orderValue = {12101,10111,11101,11111 };
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
        }*/

    public Cooker[] cookers;
    public int score;

    private void Start()
    {

    }
    void Update()
    {
        CalculateScore();
    }

    private void CalculateScore()
    {
        int cookedCount = 0;

        foreach (Cooker cooker in cookers)
        {
            if (cooker.cooked)
            {
                cookedCount++;
            }
        }

        if (cookedCount == 0)
        {
            score = 0;
            DialogueLua.SetVariable("1_2_SandWich", 0);
        }
        else if (cookedCount >= 1 && cookedCount <= 2)
        {
            score = 1;
            DialogueLua.SetVariable("1_2_SandWich", 1);
        }
        else if (cookedCount == 3)
        {
            score = 2;
            DialogueLua.SetVariable("1_2_SandWich", 2);
        }
    }
}



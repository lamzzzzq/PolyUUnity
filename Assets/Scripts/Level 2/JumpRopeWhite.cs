using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class JumpRopeWhite : MonoBehaviour
    {
        public SnapZone snapzone;
        public bool WhiteBool = false;
        // Start is called before the first frame update
        public void UpdateWhiteBool()
        {
            if (snapzone.HeldItem != null)
            {
                if (snapzone.HeldItem.name == "RopeWhite")
                {
                    WhiteBool = true;
                    //Debug.Log("That's right");
                }
                else
                {
                    WhiteBool = false;
                    //Debug.Log("No No No No~");
                }
            }
        }
    }


}
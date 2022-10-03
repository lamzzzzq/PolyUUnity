using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class JumpRopeGreen : MonoBehaviour
    {
        public SnapZone snapzone;
        public bool GreenBool = false;
        // Start is called before the first frame update
        public void UpdateGreenBool()
        {
            if (snapzone.HeldItem != null)
            {
                if (snapzone.HeldItem.name == "RopeGreen")
                {

                    Debug.Log("That's right");
                }
                else
                {
                    Debug.Log("No No No No~");
                }
            }
        }
    }


}
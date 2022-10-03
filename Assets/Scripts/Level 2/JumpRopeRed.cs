using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class JumpRopeRed : MonoBehaviour
    {
        public SnapZone snapzone;
        public bool RedBool = false;
        // Start is called before the first frame update
        public void UpdateRedBool()
        {
            if (snapzone.HeldItem != null)
            {
                if (snapzone.HeldItem.name == "RopeRed")
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
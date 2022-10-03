using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class JumpRopeYellow : MonoBehaviour
    {
        public SnapZone snapzone;
        public bool YellowBool = false;
        // Start is called before the first frame update
        public void UpdateYellowBool()
        {
            if (snapzone.HeldItem != null)
            {
                if (snapzone.HeldItem.name == "RopeYellow")
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
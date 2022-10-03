using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class JumpRopePurple : MonoBehaviour
    {
        public SnapZone snapzone;
        public bool PurpleBool = false;
        // Start is called before the first frame update
        public void UpdatePurpleBool()
        {
            if (snapzone.HeldItem != null)
            {
                if (snapzone.HeldItem.name == "RopePurple")
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
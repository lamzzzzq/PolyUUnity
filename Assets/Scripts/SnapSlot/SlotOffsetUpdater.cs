using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{

    public class SlotOffsetUpdater : MonoBehaviour
    {
        public GameObject slotObject;
        public string interactiveTag = "Interactive";

        private SnapZoneOffset slotOffset;

        private void Start()
        {
            slotOffset = slotObject.GetComponent<SnapZoneOffset>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(interactiveTag))
            {
                // 更新偏移量为相应的值
                slotOffset.LocalPositionOffset = new Vector3(0.2f, 0f, 0f);
                slotOffset.LocalRotationOffset = new Vector3(0f, 90f, -180f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(interactiveTag))
            {
                // 重置偏移量为默认值
                slotOffset.LocalPositionOffset = Vector3.zero;
                slotOffset.LocalRotationOffset = new Vector3(-90f, 0, 90);
            }
        }
    }

}

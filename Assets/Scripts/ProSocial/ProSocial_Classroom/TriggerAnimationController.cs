using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerAnimationController : MonoBehaviour
{
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    public float animationDuration = 2f;
    private bool canClose = true;
    private bool canOpen = true;
    private int npcCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("SubPlayer"))
        {
            npcCount++;
            if (canOpen)
            {
                Debug.Log("DoorOpen");
                leftDoorAnimator.SetBool("isOpen", true);
                rightDoorAnimator.SetBool("isOpen", true);
                leftDoorAnimator.SetBool("isClose", false);
                rightDoorAnimator.SetBool("isClose", false);
                canOpen = false;
                StartCoroutine(WaitForOpenAnimation());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("SubPlayer"))
        {
            npcCount--;
            if (npcCount <= 0)
            {
                npcCount = 0;
                if (canClose)
                {
                    StartCoroutine(WaitForCloseAnimation());
                }
            }
        }
    }

    IEnumerator WaitForOpenAnimation()
    {
        yield return new WaitForSeconds(animationDuration);
        canClose = true;
    }

    IEnumerator WaitForCloseAnimation()
    {
        yield return new WaitForSeconds(animationDuration);
        canOpen = true;
        leftDoorAnimator.SetBool("isClose", true);
        rightDoorAnimator.SetBool("isClose", true);

    }
}


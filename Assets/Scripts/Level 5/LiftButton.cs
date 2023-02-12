using UnityEngine;

public class LiftButton : MonoBehaviour
{
    public Transform doorTransform;
    public Vector3 openPosition;
    public float openSpeed = 1f;
    public float closeDelay = 5f;

    public bool isTriggerActive;
    private Vector3 closedPosition;

    private void Start()
    {
        closedPosition = doorTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();

        //Invoke("CloseDoor", closeDelay);
    }

/*    private void OnTriggerStay(Collider other)
    {
        CancelInvoke("CloseDoor");
        Invoke("CloseDoor", closeDelay);
    }*/


    private void OpenDoor()
    {
        doorTransform.position = Vector3.Lerp(doorTransform.position, openPosition, openSpeed * Time.deltaTime);
        isTriggerActive = true;
    }

    private void CloseDoor()
    {
        doorTransform.position = Vector3.Lerp(openPosition, closedPosition,  openSpeed * Time.deltaTime);
    }
}
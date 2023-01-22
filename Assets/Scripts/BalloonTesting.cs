using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTesting : MonoBehaviour
{
    public GameObject playerHand;
    public Rigidbody balloonRigidbody;
    public LineRenderer ropeLineRenderer;
    public float maximumRopeLength = 3f;

    public float upwardForce = 10f;
    public float ropeForce = 50f;

    private void FixedUpdate()
    {
        // Apply an upward force to the balloon
        balloonRigidbody.AddForce(Vector3.up * upwardForce);

        // Calculate the direction and distance of the rope
        Vector3 ropeDirection = playerHand.transform.position - balloonRigidbody.transform.position;
        float distance = ropeDirection.magnitude;

        // Check if the distance is greater than the maximum rope length
        if (distance > maximumRopeLength)
        {
            // Set the position of the balloon to the maximum rope length away from the player's hand
            ropeDirection.Normalize();
            ropeDirection *= maximumRopeLength;
            balloonRigidbody.position = playerHand.transform.position + ropeDirection;
        }
        else
        {
            ropeDirection.Normalize();
            // Apply a force to the balloon in the opposite direction of the rope
            balloonRigidbody.AddForce(-ropeDirection * distance * ropeForce);
        }

        // Update the rope line renderer
        ropeLineRenderer.SetPosition(0, balloonRigidbody.transform.position);
        ropeLineRenderer.SetPosition(1, playerHand.transform.position);
    }

}

using UnityEngine;

public class FruitBagLogic : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the entered object has a specific tag or meets other conditions.
        // For example, only objects with the tag "Item" will become a child of the bag.
        if (collision.gameObject.CompareTag("Interactive"))
        {
            // Make the entered object a child of the bag.
            collision.transform.SetParent(transform);
        }
    }
}

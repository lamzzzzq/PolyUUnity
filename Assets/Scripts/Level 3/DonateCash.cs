using UnityEngine;

public class DonateCash : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactive"))
        {
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DonateCash : MonoBehaviour
{
    public GameObject bowl;

    void OnCollisionEnter(Collision collision)
    {
        foreach (var item in bowl.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }


        if (collision.gameObject.CompareTag("Interactive"))
        {
            Destroy(gameObject);
        }
    }
}

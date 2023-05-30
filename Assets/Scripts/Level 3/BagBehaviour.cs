using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using BNG;

public class BagBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public List<GameObject> appleObj;
    public List<GameObject> pearObj;
    private int currentAppleIndex = 0; // Keep track of the current apple object index
    private int currentPearIndex = 0;

    public TeleportPlayerFade teleport;
    public ScreenFader ScreenFader;
    public GameObject FruitLady;
    public Transform PlayerPosition;

    private bool startCutScene = false;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Apple") && currentAppleIndex < appleObj.Count)
        {
            other.gameObject.SetActive(false);

            audioSource.PlayOneShot(audioClip);

            appleObj[currentAppleIndex].SetActive(true); // Activate the corresponding object in the bag
            currentAppleIndex++; // Increment the index for the next object
            Debug.Log(currentAppleIndex);
        }

        if (other.CompareTag("Pear") && currentPearIndex < pearObj.Count)
        {
            other.gameObject.SetActive(false);

            audioSource.PlayOneShot(audioClip);

            pearObj[currentPearIndex].SetActive(true); // Activate the corresponding object in the bag
            currentPearIndex++; // Increment the index for the next object
            Debug.Log(currentPearIndex);
        }

        if (currentAppleIndex == 3 && currentPearIndex == 2 && !startCutScene)
        {
            StartConversation();
            startCutScene = true;
        }
    }

    private void StartConversation()
    {
        StartCoroutine(Conversation());
        Debug.Log("1");
    }

    private IEnumerator Conversation()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("2");

        //teleport.targetRotation = Quaternion.Euler(rotationDegree);
        teleport.ResetPlayerPosRotWithParameters(PlayerPosition, ScreenFader);


        foreach (var trigger in FruitLady.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }

        Debug.Log("3");
    }



}

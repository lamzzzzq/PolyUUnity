using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class DonationOnPlayer : MonoBehaviour
{
    private CharacterController playerController;
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform playerPosition;

    public GameObject change1, change2;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void TransportToDonation()
    {
        //Disable Movement
        playerController.enabled = false;
        //Transport to a position and specific rotation degrees
        teleport.ResetPlayerPosRotWithParameters(playerPosition, screenFader);
        StartCoroutine(delay());
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        playerController.enabled = true;
    }

    public void ActiveChange()
    {
        StartCoroutine(ActiveAfterConversation());
    }

    private IEnumerator ActiveAfterConversation()
    {
        yield return new WaitForSeconds(6f);
        change1.SetActive(true);
        change2.SetActive(true);
    }
}

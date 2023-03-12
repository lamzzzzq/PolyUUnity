using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using BNG;


public class TeleportationPosition : MonoBehaviour
{
    public GameObject target;
    public GameObject exitPosition;
    public GameObject player;
    public GameObject confirmUI;
    // Start is called before the first frame update

    private bool isFade;
    //fadeCanvasGroup是用来调整alpha值0-1
    public CanvasGroup fadeCanvasGroup;

    public float fadeDuration;


    PlayerTeleport teleport;
    ScreenFader sf;


    public void teleportationPosition()
    {

        //player.transform.position = target.transform.position;
        //StartCoroutine(Transition());
        teleport.TeleportPlayerToTransform(target.transform);
    }

    private IEnumerator Transition()
    {

        yield return Fade(1);

        player.transform.position = target.transform.position;

        yield return Fade(0);
    }

    public void DisableMovement()
    {
        player.GetComponent<CharacterController>().enabled = false;
    }

    public void ExitJet()
    {
        player.transform.position = exitPosition.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void DisableConfirmUI()
    {
        Destroy(confirmUI);
    }



    private IEnumerator Fade(float targetAlpha)
    {
        //isFade用来判断是不是正在切换场景，所以协程一开始就要变成true
        isFade = true;

        //拒绝交互
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        //fadeCanvas.alpha和targetAlpha在数学上两个值差不多不相等
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            //这句话是让协程卡在这里，直到执行完成才能离开
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }

}

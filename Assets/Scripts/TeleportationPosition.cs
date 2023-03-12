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
    //fadeCanvasGroup����������alphaֵ0-1
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
        //isFade�����ж��ǲ��������л�����������Э��һ��ʼ��Ҫ���true
        isFade = true;

        //�ܾ�����
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        //fadeCanvas.alpha��targetAlpha����ѧ������ֵ��಻���
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            //��仰����Э�̿������ֱ��ִ����ɲ����뿪
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }

}

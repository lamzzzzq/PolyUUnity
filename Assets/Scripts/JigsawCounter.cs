using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawCounter : MonoBehaviour
{
    public Text text;

    public int openedArts = 0;
    public bool[] artOpened;   // 用于追踪哪些画已经被展开

    public GameObject fadeScreen;

    void Start()
    {
        artOpened = new bool[20];  // 假设有 20 幅画
    }

    private void Update()
    {
        // Find the GameObject by name
        GameObject myGameObject = GameObject.Find("Collider");

        // Check if GameObject was found
        if (myGameObject != null)
        {
            // Find the script component attached to the GameObject
            UIMove myScript = myGameObject.GetComponent<UIMove>();

            // Call a method on the script
            if (myScript != null)
            {
                text.text = myScript.solvedJigsawCount.ToString();
                if (openedArts == 20 && myScript.solvedJigsawCount == 5)
                {
                    StartCoroutine(DelayForFiveSeconds());
                }
            }
        }
        else
        {
            Debug.LogWarning("GameObject named 'Collider' was not found.");
        }
    }


    public void OpenArts(int artIndex)
    {
        if(!artOpened[artIndex])
        {
            openedArts = openedArts + 1;

            artOpened[artIndex] = true;
        }

        Debug.Log(openedArts);

    }

    private IEnumerator DelayForFiveSeconds()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Complete!");
        fadeScreen.SetActive(true);
    }

}

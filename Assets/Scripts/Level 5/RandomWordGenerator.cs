using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordGenerator : MonoBehaviour
{
    public Text guidelineText;
    public static string randomWord;

    private void Start()
    {
        string originalGuideline = guidelineText.text;

        //generate a random word from the word pool
        string[] wordPool = { "glasses", "radio", "medicine" };
        int randomIndex = Random.Range(0, wordPool.Length);
        randomWord = wordPool[randomIndex];

        string newGuideline = originalGuideline.Replace("THEWORD", "<color=yellow>" + randomWord + "</color>");
        guidelineText.text = newGuideline;
    }


}

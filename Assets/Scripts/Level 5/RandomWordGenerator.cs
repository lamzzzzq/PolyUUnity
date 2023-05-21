using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;//First

public class RandomWordGenerator : MonoBehaviour
{
    public Text guidelineText;
    public string randomWord;
    public string randomWordForCheck;

    private void Start()
    {
        //«@È¡®”Ç°LocaleCode
        Locale currentLocale = LocalizationSettings.SelectedLocale;
        string localeCode = currentLocale.Identifier.Code;
        string originalGuideline = guidelineText.text;
        Debug.Log("Current Locale: " + localeCode);

        //generate a random word from the word pool
        string[] wordPool1 = { "glasses", "radio", "slipper","clothes" };
        string[] wordPool2 = { "ÑÛçR", "ÊÕÒô™C", "ÍÏÐ¬","TÐô" };


        if (localeCode == "zh-HK")
        {
            int Index = Random.Range(0, wordPool2.Length);
            randomWord = wordPool2[Index];
            randomWordForCheck = wordPool1[Index];

            Debug.Log("this is zh-HK, RandomWord is: " + randomWord);
            Debug.Log("this is zh-HK, RandomWordForCheck is: " + randomWordForCheck);
        }
        else
        {
            int Index = Random.Range(0, wordPool1.Length);
            randomWord = wordPool1[Index];
            randomWordForCheck = wordPool1[Index];
            Debug.Log("this is not zh-HK, RandomWord is: " + randomWord);
            Debug.Log("this is not zh-HK, RandomWordForCheck is: " + randomWordForCheck);
        }

        string newGuideline = originalGuideline.Replace("THEWORD", "<color=yellow>" + randomWord + "</color>");
        guidelineText.text = newGuideline;
    }


}

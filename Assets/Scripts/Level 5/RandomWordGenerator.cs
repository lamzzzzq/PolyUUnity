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
    public AudioSource audioSource;
    public GameObject panel;
    public AudioClip glasses, radio, slipper, clothes;

    private void Start()
    {
        //獲取當前LocaleCode
        //Locale currentLocale = LocalizationSettings.SelectedLocale;
        //string localeCode = currentLocale.Identifier.Code;
        string originalGuideline = guidelineText.text;
        //Debug.Log("Current Locale: " + localeCode);

        //generate a random word from the word pool
        //string[] wordPool1 = { "glasses", "radio", "slipper","clothes" };
        string[] wordPool = { "眼鏡", "收音機", "拖鞋","T恤" };


        /*        if (localeCode == "zh-HK")
                {
                    int Index = Random.Range(0, wordPool2.Length);
                    randomWord = wordPool2[Index];
                    randomWordForCheck = wordPool1[Index];

                    Debug.Log("this is zh-HK, RandomWord is: " + randomWord);
                    Debug.Log("this is zh-HK, RandomWordForCheck is: " + randomWordForCheck);

                    switch (randomWord)
                    {
                        case "眼鏡":
                            PlayAudio(glasses);
                            break;
                        case "收音機":
                            PlayAudio(radio);
                            break;
                        case "拖鞋":
                            PlayAudio(slipper);
                            break;
                        case "T恤":
                            PlayAudio(clothes);
                            break;
                        default:
                            // 默认情况下不执行任何逻辑
                            break;
                    }

                }
                else
                {*/
        //Fix Later: ONLY USE TC HERE

        int Index = Random.Range(0, wordPool.Length);
        randomWord = wordPool[Index];
        //randomWordForCheck = wordPool1[Index];
        //Debug.Log("this is not zh-HK, RandomWord is: " + randomWord);
        //Debug.Log("this is not zh-HK, RandomWordForCheck is: " + randomWordForCheck);

        switch (randomWord)
        {
            case "眼鏡":
                PlayAudio(glasses);
                break;
            case "收音機":
                PlayAudio(radio);
                break;
            case "拖鞋":
                PlayAudio(slipper);
                break;
            case "T恤":
                PlayAudio(clothes);
                break;
            default:
                // 默认情况下不执行任何逻辑
                break;
        }

        string newGuideline = originalGuideline.Replace("THEWORD", "<color=yellow>" + randomWord + "</color>");
        guidelineText.text = newGuideline;
    }

    private void PlayAudio(AudioClip audio)
    {
        StartCoroutine(PlayAudioAndDisableText(audio));
    }

    private IEnumerator PlayAudioAndDisableText(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        // Disable the text here
        guidelineText.enabled = false;
        panel.SetActive(false);
    }



}

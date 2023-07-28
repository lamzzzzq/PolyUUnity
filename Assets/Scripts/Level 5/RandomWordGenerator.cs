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
        //�@ȡ��ǰLocaleCode
        //Locale currentLocale = LocalizationSettings.SelectedLocale;
        //string localeCode = currentLocale.Identifier.Code;
        string originalGuideline = guidelineText.text;
        //Debug.Log("Current Locale: " + localeCode);

        //generate a random word from the word pool
        //string[] wordPool1 = { "glasses", "radio", "slipper","clothes" };
        string[] wordPool = { "���R", "�����C", "��Ь","T��" };


        /*        if (localeCode == "zh-HK")
                {
                    int Index = Random.Range(0, wordPool2.Length);
                    randomWord = wordPool2[Index];
                    randomWordForCheck = wordPool1[Index];

                    Debug.Log("this is zh-HK, RandomWord is: " + randomWord);
                    Debug.Log("this is zh-HK, RandomWordForCheck is: " + randomWordForCheck);

                    switch (randomWord)
                    {
                        case "���R":
                            PlayAudio(glasses);
                            break;
                        case "�����C":
                            PlayAudio(radio);
                            break;
                        case "��Ь":
                            PlayAudio(slipper);
                            break;
                        case "T��":
                            PlayAudio(clothes);
                            break;
                        default:
                            // Ĭ������²�ִ���κ��߼�
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
            case "���R":
                PlayAudio(glasses);
                break;
            case "�����C":
                PlayAudio(radio);
                break;
            case "��Ь":
                PlayAudio(slipper);
                break;
            case "T��":
                PlayAudio(clothes);
                break;
            default:
                // Ĭ������²�ִ���κ��߼�
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

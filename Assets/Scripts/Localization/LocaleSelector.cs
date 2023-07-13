using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;//First


public class LocaleSelector : MonoBehaviour
{
    private bool active = false;

    private void Start()
    {
        //int ID = PlayerPrefs.GetInt("LocaleKey", 1 );

        StartCoroutine(SetLocale(1));


        Locale currentLocale = LocalizationSettings.SelectedLocale;
        string localeCode = currentLocale.Identifier.Code;
        Debug.Log("Current Locale: " + localeCode);
    }

    public void ChangeLocale(int localeID)
    {
        if (active == true)
        {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }

    //IEnumerator function
    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class idioma : MonoBehaviour
{
    // Start is called before the first frame update
  public void CambiarIdioma(int indiceIdioma)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indiceIdioma];
    }
}

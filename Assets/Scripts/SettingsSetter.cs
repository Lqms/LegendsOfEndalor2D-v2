using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class SettingsSetter : MonoBehaviour, ISceneLoadHandler<SettingsConfig>
{
    public void OnSceneLoaded(SettingsConfig argument)
    {
        Debug.Log("√ромкость: " + argument.Volume);
        Debug.Log("язык: " + argument.Language);
        Debug.Log("–азрешение: " + argument.Resolution[0] + "х" + argument.Resolution[1]);
    }
}

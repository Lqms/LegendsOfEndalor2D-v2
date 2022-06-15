using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class SettingsSetter : MonoBehaviour, ISceneLoadHandler<SettingsConfig>
{
    public void OnSceneLoaded(SettingsConfig argument)
    {
        Debug.Log("���������: " + argument.Volume);
        Debug.Log("����: " + argument.Language);
        Debug.Log("����������: " + argument.Resolution[0] + "�" + argument.Resolution[1]);
    }
}
